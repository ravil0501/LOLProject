using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LOLProject.Model;

public partial class LolprojectContext : DbContext
{
    public LolprojectContext()
    {
    }

    public LolprojectContext(DbContextOptions<LolprojectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaseScale> BaseScales { get; set; }

    public virtual DbSet<Hero> Heroes { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemsDifference> ItemsDifferences { get; set; }

    public virtual DbSet<ItemsDifferent> ItemsDifferents { get; set; }

    public virtual DbSet<Key> Keys { get; set; }

    public virtual DbSet<KeySkill> KeySkills { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<LevelSkill> LevelSkills { get; set; }

    public virtual DbSet<LevelsHero> LevelsHeroes { get; set; }

    public virtual DbSet<Scale> Scales { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillHero> SkillHeroes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-25N2UER8;Database=LOLPROJECT;TrustServerCertificate=True;Integrated Security=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseScale>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ad).HasColumnName("AD");
            entity.Property(e => e.NameHero).HasMaxLength(50);
            entity.Property(e => e.SpeedAttack).HasColumnName("Speed_Attack");

            entity.HasOne(d => d.NameHeroNavigation).WithMany(p => p.BaseScales)
                .HasForeignKey(d => d.NameHero)
                .HasConstraintName("FK_BaseScales_Heroes");
        });

        modelBuilder.Entity<Hero>(entity =>
        {
            entity.HasKey(e => e.NameHero);

            entity.Property(e => e.NameHero).HasMaxLength(50);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(e => e.Ad).HasColumnName("AD");
            entity.Property(e => e.Ap).HasColumnName("AP");
            entity.Property(e => e.AttackSpeed).HasColumnName("Attack_speed");
            entity.Property(e => e.Hp).HasColumnName("HP");
            entity.Property(e => e.ItemName).HasMaxLength(50);
        });

        modelBuilder.Entity<ItemsDifference>(entity =>
        {
            entity.ToTable("Items_Difference");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IdDiff).HasColumnName("Id_Diff");
            entity.Property(e => e.IdItem).HasColumnName("Id_Item");

            entity.HasOne(d => d.IdDiffNavigation).WithMany(p => p.ItemsDifferences)
                .HasForeignKey(d => d.IdDiff)
                .HasConstraintName("FK_Items_Difference_ItemsDifferents");

            entity.HasOne(d => d.IdItemNavigation).WithMany(p => p.ItemsDifferences)
                .HasForeignKey(d => d.IdItem)
                .HasConstraintName("FK_Items_Difference_Items");
        });

        modelBuilder.Entity<ItemsDifferent>(entity =>
        {
            entity.Property(e => e.ItemsDiff).HasMaxLength(50);
        });

        modelBuilder.Entity<Key>(entity =>
        {
            entity.HasKey(e => e.IdKeys);

            entity.Property(e => e.IdKeys).ValueGeneratedNever();
            entity.Property(e => e.KeySkill)
                .HasMaxLength(50)
                .HasColumnName("Key_skill");
        });

        modelBuilder.Entity<KeySkill>(entity =>
        {
            entity.ToTable("Key_skill");

            entity.Property(e => e.KeySkill1).HasColumnName("KeySkill");
            entity.Property(e => e.NameSkill).HasMaxLength(50);

            entity.HasOne(d => d.KeySkill1Navigation).WithMany(p => p.KeySkills)
                .HasForeignKey(d => d.KeySkill1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Key_skill_Keys");

            entity.HasOne(d => d.NameSkillNavigation).WithMany(p => p.KeySkills)
                .HasForeignKey(d => d.NameSkill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Key_skill_Skills");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.LevelSkill);

            entity.Property(e => e.LevelSkill)
                .ValueGeneratedNever()
                .HasColumnName("Level_Skill");
        });

        modelBuilder.Entity<LevelSkill>(entity =>
        {
            entity.ToTable("Level_Skill");

            entity.Property(e => e.LevelSkill1).HasColumnName("LevelSkill");
            entity.Property(e => e.NameSkill).HasMaxLength(50);

            entity.HasOne(d => d.LevelSkill1Navigation).WithMany(p => p.LevelSkills)
                .HasForeignKey(d => d.LevelSkill1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Level_Skill_Levels");

            entity.HasOne(d => d.NameSkillNavigation).WithMany(p => p.LevelSkills)
                .HasForeignKey(d => d.NameSkill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Level_Skill_Skills");
        });

        modelBuilder.Entity<LevelsHero>(entity =>
        {
            entity.HasKey(e => e.NumberLevel).HasName("PK_Уровень");

            entity.ToTable("Levels_Hero");

            entity.Property(e => e.NumberLevel)
                .ValueGeneratedNever()
                .HasColumnName("Number_level");
        });

        modelBuilder.Entity<Scale>(entity =>
        {
            entity.Property(e => e.NameHero).HasMaxLength(50);

            entity.HasOne(d => d.NameHeroNavigation).WithMany(p => p.Scales)
                .HasForeignKey(d => d.NameHero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scales_Heroes");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.NameSkills);

            entity.Property(e => e.NameSkills).HasMaxLength(50);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<SkillHero>(entity =>
        {
            entity.ToTable("Skill_Hero");

            entity.Property(e => e.NameHero).HasMaxLength(50);
            entity.Property(e => e.Nameskill).HasMaxLength(50);

            entity.HasOne(d => d.NameHeroNavigation).WithMany(p => p.SkillHeroes)
                .HasForeignKey(d => d.NameHero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Skill_Hero_Heroes");

            entity.HasOne(d => d.NameskillNavigation).WithMany(p => p.SkillHeroes)
                .HasForeignKey(d => d.Nameskill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Skill_Hero_Skills");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
