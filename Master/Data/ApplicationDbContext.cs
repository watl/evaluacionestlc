using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EvalCore.Models;

namespace EvalCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Cargos>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PK__Cargos__7D16AF24342578CA");

                entity.Property(e => e.CarId)
                    .HasColumnName("CAR_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CarDescripcion)
                    .IsRequired()
                    .HasColumnName("CAR_Descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CarFechaAud)
                    .HasColumnName("CAR_FechaAud")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CarHomologado)
                    .IsRequired()
                    .HasColumnName("CAR_Homologado")
                    .HasDefaultValueSql("((1))")
                    .HasComment("Cargos que estan definidos en el Decreto 128-2005");

                entity.Property(e => e.CarNombre)
                    .IsRequired()
                    .HasColumnName("CAR_Nombre")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CarUsuarioAud)
                    .HasColumnName("CAR_UsuarioAud")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())")
                    .HasComment("Usuario que agrega el cargo");
            });

            modelBuilder.Entity<DepartamentoProyectos>(entity =>
            {
                entity.HasKey(e => e.KeyDepartamentoProyecto)
                    .HasName("PK__Departam__463E2A671862B401");

                entity.ToTable("Departamento_Proyectos");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedUser)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.DirId)
                    .HasColumnName("Dir_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DptCentroCosto)
                    .HasColumnName("DPT_Centro_Costo")
                    .HasMaxLength(11);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Observacion)
                    .HasColumnName("observacion")
                    .HasMaxLength(150);
            });

       
            modelBuilder.Entity<Direcciones>(entity =>
            {
                entity.HasKey(e => e.DirId)
                    .HasName("PK__Direccio__B28024E272FFC504");

                entity.Property(e => e.DirId)
                    .HasColumnName("DIR_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DirActivo)
                    .HasColumnName("DIR_Activo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DirCentroCosto)
                    .HasColumnName("DIR_Centro_Costo")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DirDescripcion)
                    .HasColumnName("DIR_Descripcion")
                    .HasColumnType("text");

                entity.Property(e => e.DirFechaAud)
                    .HasColumnName("DIR_FechaAUD")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DirNombre)
                    .IsRequired()
                    .HasColumnName("DIR_Nombre")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.DirUsuarioAud)
                    .HasColumnName("DIR_UsuarioAUD")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");
            });

     

            modelBuilder.Entity<Funcionarios>(entity =>
            {
                entity.HasKey(e => e.FunId)
                    .HasName("PK__Funciona__C450C31063BD3644");

                entity.HasIndex(e => new { e.FunId, e.DirId, e.FunCodigo })
                    .HasName("IX_FUNIONARIO_FUN_CODIGO");

                entity.Property(e => e.FunId)
                    .HasColumnName("FUN_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CarId)
                    .HasColumnName("CAR_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DepId).HasColumnName("Dep_id");

                entity.Property(e => e.DirId)
                    .HasColumnName("DIR_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FunActivo).HasColumnName("FUN_Activo");

                entity.Property(e => e.FunApellidos)
                    .IsRequired()
                    .HasColumnName("FUN_Apellidos")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FunCedula)
                    .HasColumnName("FUN_Cedula")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FunCodigo)
                    .HasColumnName("FUN_CODIGO")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FunDireccion)
                    .HasColumnName("FUN_Direccion")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FunFechaIngreso)
                    .HasColumnName("FUN_Fecha_Ingreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.FunFnac)
                    .HasColumnName("FUN_FNac")
                    .HasColumnType("datetime");

                entity.Property(e => e.FunIngreso)
                    .HasColumnName("FUN_Ingreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.FunNombre)
                    .IsRequired()
                    .HasColumnName("FUN_Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.JefeId)
                    .HasColumnName("JEFE_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.KeyDepartamentoProy).HasDefaultValueSql("((0))");

                entity.Property(e => e.SexoId)
                    .HasColumnName("SEXO_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_Funcionarios_Cargos");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK_Funcionarios_Departamento_Proyectos");

                entity.HasOne(d => d.Dir)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.DirId)
                    .HasConstraintName("FK_Funcionarios_Direcciones");
            });

            modelBuilder.Entity<Ponderacion>(entity =>
            {
                entity.Property(e => e.Id).HasComment("clave primaria");

                entity.Property(e => e.Activo).HasComment("estado para eliminacion logica");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("detalle de agrupacion de pregunta");

                entity.Property(e => e.Valor).HasComment("valor de ponderacion");
            });

            modelBuilder.Entity<Pregunta>(entity =>
            {
                entity.Property(e => e.Id).HasComment("Key pregunta");

                entity.Property(e => e.Activo).HasComment("estado de pregunta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("detalle de pregunta");

                entity.Property(e => e.FkPndId)
                    .HasColumnName("Fk_pndID")
                    .HasComment("Fk table ponderacion contiene bloques de preguntas");

                entity.HasOne(d => d.FkPnd)
                    .WithMany(p => p.Pregunta)
                    .HasForeignKey(d => d.FkPndId)
                    .HasConstraintName("FK_Pregunta_Ponderacion");
            });

            modelBuilder.Entity<Tpevaluacion>(entity =>
            {
                entity.Property(e => e.Id).HasComment("clave primaria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Detalle de evaluacion");
            });

            modelBuilder.Entity<Evaluaciodetalle>(entity =>
            {
                entity.HasKey(e => e.KeyEvdt)
                    .HasName("PK__Evaluaci__3214EC0707CAC434");

                entity.Property(e => e.KeyEvdt).HasComment("Clave primaria evaluacion detalle");

                entity.Property(e => e.Blq1).HasComment("total bloque 1");

                entity.Property(e => e.Blq2).HasComment("total bloque 2");

                entity.Property(e => e.Blq3).HasComment("total bloque 3");

                entity.Property(e => e.Blq4).HasComment("total bloque 4");

                entity.Property(e => e.Bltotal).HasComment("puntaje total de evaluacion");

                entity.Property(e => e.CarId).HasComment("Fk cargo historial");

                entity.Property(e => e.DirId).HasComment("Fk direccion historial");

                entity.Property(e => e.Fkeva).HasComment("Fk tabla evaluaciones");

                entity.Property(e => e.Fkfunceval)
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Fk Funcionario que  evalua");

                entity.Property(e => e.Fktipoeva).HasComment("Fk tipo evaluacion");

                entity.Property(e => e.FunId)
                    .HasColumnName("FunID")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Fk Funcionario evaluado");

                entity.Property(e => e.Pntescala)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Escala de puntaje tipo string");

                entity.Property(e => e.Rtcapc)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("capacitaciones");

                entity.Property(e => e.Rtcomp)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("compromisos");

                entity.Property(e => e.Rtdeb)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("debilidades");

                entity.Property(e => e.Rtfort)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("fortalezas");
            });



       
            modelBuilder.Entity<Evaluacion>(entity =>
            {
                entity.HasKey(e => e.KeyEval)
                    .HasName("PK__Evaluaci__3214EC07E39D0555");

                entity.Property(e => e.KeyEval).HasComment("clave primaria tabla evaluacion Header");

                entity.Property(e => e.Estado).HasComment("Estado periodo para poder seleccionarlo en formulario crear evaluacion");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime")
                    .HasComment("fecha de evaluacion");

                entity.Property(e => e.Periodofinal)
                    .HasColumnType("date")
                    .HasComment("periodo final fecha");

                entity.Property(e => e.Periodoinicial)
                    .HasColumnType("date")
                    .HasComment("periodo inicial fecha");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("usuario del sistema ");
            });

            modelBuilder.Entity<Detallepregunta>(entity =>
            {
                entity.HasKey(e => e.KeyDtpreg)
                    .HasName("PK__Detallep__3214EC07737E2926");

                entity.Property(e => e.KeyDtpreg).HasComment("Key DetallePregunta");

                entity.Property(e => e.FkPreguntaId)
                    .HasColumnName("Fk_preguntaID")
                    .HasComment("Fk tabla pregunta");

                entity.Property(e => e.Fkdtevalua).HasComment("Fk tabla detalle evaluacion");

                entity.Property(e => e.Puntpregunta)
                    .HasColumnName("puntpregunta")
                    .HasComment("puntaje por cada pregunta del 1 al 4");
            });


        }

        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<DepartamentoProyectos> DepartamentoProyectos { get; set; }

        public virtual DbSet<Direcciones> Direcciones { get; set; }
  
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<Ponderacion> Ponderacion { get; set; }
        public virtual DbSet<Pregunta> Pregunta { get; set; }
        public virtual DbSet<Tpevaluacion> Tpevaluacion { get; set; }

    
        public virtual DbSet<Evaluacion> Evaluacion { get; set; }
        public virtual DbSet<Evaluaciodetalle> Evaluaciodetalle { get; set; }

        public virtual DbSet<Detallepregunta> Detallepregunta { get; set; }


    }
}
