﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext() 
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Clientfeedback> Clientfeedbacks { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employeetask> Employeetasks { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Meeting> Meetings { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Projectdocument> Projectdocuments { get; set; }

    public virtual DbSet<Projecttechnology> Projecttechnologies { get; set; }

    public virtual DbSet<api.Models.Task> Tasks { get; set; }

    public virtual DbSet<Taskstatus> Taskstatuses { get; set; }

    public virtual DbSet<Technology> Technologies { get; set; }

    public virtual DbSet<Worklog> Worklogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=127.0.0.2;port=3306;database=aucusoft;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.24-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.ContactPerson).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Industry).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Clientfeedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PRIMARY");

            entity.ToTable("clientfeedback");

            entity.HasIndex(e => e.ClientId, "ClientID");

            entity.HasIndex(e => e.ProjectId, "ProjectID");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Text).HasColumnType("text");

            entity.HasOne(d => d.Client).WithMany(p => p.Clientfeedbacks)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("clientfeedback_ibfk_2");

            entity.HasOne(d => d.Project).WithMany(p => p.Clientfeedbacks)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("clientfeedback_ibfk_1");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PRIMARY");

            entity.ToTable("departments");

            entity.HasIndex(e => e.ManagerId, "fk_departments_managers");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Manager).WithMany(p => p.Departments)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_departments_managers");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employees");

            entity.HasIndex(e => e.DepartmentId, "DepartmentID");

            entity.HasIndex(e => e.PositionId, "PositionID");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.PositionId).HasColumnName("PositionID");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("employees_ibfk_2");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("employees_ibfk_1");
        });

        modelBuilder.Entity<Employeetask>(entity =>
        {
            entity.HasKey(e => e.EmployeeTaskId).HasName("PRIMARY");

            entity.ToTable("employeetasks");

            entity.HasIndex(e => e.TaskId, "TaskID");

            entity.HasIndex(e => e.EmployeeId, "employeetasks_ibfk_2");

            entity.Property(e => e.EmployeeTaskId).HasColumnName("EmployeeTaskID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.HasOne(d => d.Employee).WithMany(p => p.Employeetasks)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("employeetasks_ibfk_2");

            entity.HasOne(d => d.Task).WithMany(p => p.Employeetasks)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("employeetasks_ibfk_1");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PRIMARY");

            entity.ToTable("managers");

            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Position).HasMaxLength(255);
        });

        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.HasKey(e => e.MeetingId).HasName("PRIMARY");

            entity.ToTable("meetings");

            entity.HasIndex(e => e.ProjectId, "ProjectID");

            entity.Property(e => e.MeetingId).HasColumnName("MeetingID");
            entity.Property(e => e.Agenda).HasColumnType("text");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Project).WithMany(p => p.Meetings)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("meetings_ibfk_1");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PRIMARY");

            entity.ToTable("positions");

            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PRIMARY");

            entity.ToTable("projects");

            entity.HasIndex(e => e.ClientId, "ClientID");

            entity.HasIndex(e => e.ProjectManagerId, "ProjectManagerID");

            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Budget).HasPrecision(10, 2);
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ProjectManagerId).HasColumnName("ProjectManagerID");

            entity.HasOne(d => d.Client).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("projects_ibfk_1");

            entity.HasOne(d => d.ProjectManager).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProjectManagerId)
                .HasConstraintName("projects_ibfk_2");
        });

        modelBuilder.Entity<Projectdocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PRIMARY");

            entity.ToTable("projectdocuments");

            entity.HasIndex(e => e.ProjectId, "ProjectID");

            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.DocumentPath).HasMaxLength(255);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Project).WithMany(p => p.Projectdocuments)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("projectdocuments_ibfk_1");
        });

        modelBuilder.Entity<Projecttechnology>(entity =>
        {
            entity.HasKey(e => e.ProjectTechnologyId).HasName("PRIMARY");

            entity.ToTable("projecttechnologies");

            entity.HasIndex(e => e.ProjectId, "ProjectID");

            entity.HasIndex(e => e.TechnologyId, "TechnologyID");

            entity.Property(e => e.ProjectTechnologyId).HasColumnName("ProjectTechnologyID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.TechnologyId).HasColumnName("TechnologyID");

            entity.HasOne(d => d.Project).WithMany(p => p.Projecttechnologies)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("projecttechnologies_ibfk_1");

            entity.HasOne(d => d.Technology).WithMany(p => p.Projecttechnologies)
                .HasForeignKey(d => d.TechnologyId)
                .HasConstraintName("projecttechnologies_ibfk_2");
        });

        modelBuilder.Entity<api.Models.Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PRIMARY");

            entity.ToTable("tasks");

            entity.HasIndex(e => e.AssignedTo, "AssignedTo");

            entity.HasIndex(e => e.ProjectId, "ProjectID");

            entity.HasIndex(e => e.StatusId, "StatusID");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.AssignedTo)
                .HasConstraintName("tasks_ibfk_2");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("tasks_ibfk_1");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("tasks_ibfk_3");
        });

        modelBuilder.Entity<Taskstatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PRIMARY");

            entity.ToTable("taskstatuses");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Technology>(entity =>
        {
            entity.HasKey(e => e.TechnologyId).HasName("PRIMARY");

            entity.ToTable("technologies");

            entity.Property(e => e.TechnologyId).HasColumnName("TechnologyID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Worklog>(entity =>
        {
            entity.HasKey(e => e.WorkLogId).HasName("PRIMARY");

            entity.ToTable("worklogs");

            entity.HasIndex(e => e.EmployeeId, "EmployeeID");

            entity.HasIndex(e => e.ProjectId, "ProjectID");

            entity.Property(e => e.WorkLogId).HasColumnName("WorkLogID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Employee).WithMany(p => p.Worklogs)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("worklogs_ibfk_1");

            entity.HasOne(d => d.Project).WithMany(p => p.Worklogs)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("worklogs_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
