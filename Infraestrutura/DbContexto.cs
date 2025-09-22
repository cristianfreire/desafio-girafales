using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio_girafales.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;


namespace desafio_girafales.Infraestrutura
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectPrerequisite> SubjectPrerequisites { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Building> Buildings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Professor -> Department
            modelBuilder.Entity<Professor>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Professors)
                .HasForeignKey(p => p.DepartmentId);

            // Professor -> Title
            modelBuilder.Entity<Professor>()
                .HasOne(p => p.Title)
                .WithMany(t => t.Professors)
                .HasForeignKey(p => p.TitleId);

            // SubjectPrerequisite -> Subject
            modelBuilder.Entity<SubjectPrerequisite>()
                .HasOne(sp => sp.Subject)
                .WithMany(s => s.Prerequisites)
                .HasForeignKey(sp => sp.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SubjectPrerequisite>()
                .HasOne(sp => sp.Prerequisite)
                .WithMany()
                .HasForeignKey(sp => sp.PrerequisiteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Class -> Subject
            modelBuilder.Entity<Class>()
                .HasOne(c => c.Subject)
                .WithMany(s => s.Classes)
                .HasForeignKey(c => c.SubjectId);

            // ClassSchedule -> Class
            modelBuilder.Entity<ClassSchedule>()
                .HasOne(cs => cs.Class)
                .WithMany(c => c.Schedules)
                .HasForeignKey(cs => cs.ClassId);

            // ClassSchedule -> Room
            modelBuilder.Entity<ClassSchedule>()
                .HasOne(cs => cs.Room)
                .WithMany(r => r.Schedules)
                .HasForeignKey(cs => cs.RoomId);

            // Room -> Building
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Building)
                .WithMany(b => b.Rooms)
                .HasForeignKey(r => r.BuildingId);

            base.OnModelCreating(modelBuilder);

            // Títulos
            modelBuilder.Entity<Title>().HasData(
                new Title { Id = 1, Name = "Professor Assistente" },
                new Title { Id = 2, Name = "Professor Associado" },
                new Title { Id = 3, Name = "Professor Titular" }
            );

            // Departamentos
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Ciência da Computação" },
                new Department { Id = 2, Name = "Matemática" }
            );

            // Professores
            modelBuilder.Entity<Professor>().HasData(
                new Professor { Id = 1, DepartmentId = 1, TitleId = 3 },
                new Professor { Id = 2, DepartmentId = 2, TitleId = 1 }
            );

            // Prédios
            modelBuilder.Entity<Building>().HasData(
                new Building { Id = 1, Name = "Bloco A" },
                new Building { Id = 2, Name = "Bloco B" }
            );

            // Salas
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, BuildingId = 1 },
                new Room { Id = 2, BuildingId = 1 },
                new Room { Id = 3, BuildingId = 2 }
            );

            // Disciplinas
            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, SubjectId = "CS101" },
                new Subject { Id = 2, SubjectId = "CS201" },
                new Subject { Id = 3, SubjectId = "MAT101" }
            );

            // Pré-requisitos
            modelBuilder.Entity<SubjectPrerequisite>().HasData(
                new SubjectPrerequisite { Id = 1, SubjectId = 2, PrerequisiteId = 1 }
            );

            // Turmas
            modelBuilder.Entity<Class>().HasData(
                new Class { Id = 1, SubjectId = 1, Year = 2025, Semester = 1, Code = "CS101-1" },
                new Class { Id = 2, SubjectId = 2, Year = 2025, Semester = 2, Code = "CS201-1" }
            );

            // Horários
            modelBuilder.Entity<ClassSchedule>().HasData(
                new ClassSchedule
                {
                    Id = 1,
                    ClassId = 1,
                    RoomId = 1,
                    DayOfWeek = DayOfWeek.Monday,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(10, 0, 0)
                },
                new ClassSchedule
                {
                    Id = 2,
                    ClassId = 2,
                    RoomId = 2,
                    DayOfWeek = DayOfWeek.Wednesday,
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0)
                }
            );
        }
    }
}
