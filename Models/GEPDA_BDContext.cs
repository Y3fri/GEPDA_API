using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GEPDA_API.Models
{
    public partial class GEPDA_BDContext : DbContext
    {
        public GEPDA_BDContext()
        {
        }

        public GEPDA_BDContext(DbContextOptions<GEPDA_BDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DepartamentoMunicipio> DepartamentoMunicipios { get; set; } = null!;
        public virtual DbSet<DniTipo> DniTipos { get; set; } = null!;
        public virtual DbSet<InformacionUniversidad> InformacionUniversidads { get; set; } = null!;
        public virtual DbSet<Pai> Pais { get; set; } = null!;
        public virtual DbSet<PaisDepartamento> PaisDepartamentos { get; set; } = null!;
        public virtual DbSet<ProgramaCriterio> ProgramaCriterios { get; set; } = null!;
        public virtual DbSet<SedePrograma> SedeProgramas { get; set; } = null!;
        public virtual DbSet<SedeProgramaAspirante> SedeProgramaAspirantes { get; set; } = null!;
        public virtual DbSet<SsoRol> SsoRols { get; set; } = null!;
        public virtual DbSet<SsoUsuario> SsoUsuarios { get; set; } = null!;
        public virtual DbSet<UniversidadSede> UniversidadSedes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-32FLDL7;Database=GEPDA_BD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartamentoMunicipio>(entity =>
            {
                entity.HasKey(e => e.MunId);

                entity.ToTable("Departamento_municipio");

                entity.Property(e => e.MunId).HasColumnName("mun_id");

                entity.Property(e => e.MunCodigoDane)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("mun_codigo_dane");

                entity.Property(e => e.MunDep).HasColumnName("mun_dep");

                entity.Property(e => e.MunNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("mun_nombre");

                entity.HasOne(d => d.MunDepNavigation)
                    .WithMany(p => p.DepartamentoMunicipios)
                    .HasForeignKey(d => d.MunDep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departamento_municipio_Pais_departamento");
            });

            modelBuilder.Entity<DniTipo>(entity =>
            {
                entity.HasKey(e => e.DniId);

                entity.ToTable("Dni_tipo");

                entity.Property(e => e.DniId).HasColumnName("dni_id");

                entity.Property(e => e.DniDescripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("dni_descripcion");

                entity.Property(e => e.DniNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("dni_nombre");
            });

            modelBuilder.Entity<InformacionUniversidad>(entity =>
            {
                entity.HasKey(e => e.UniId);

                entity.ToTable("Informacion_universidad");

                entity.Property(e => e.UniId).HasColumnName("uni_id");

                entity.Property(e => e.UniDireccionPrincipal)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("uni_direccion_principal");

                entity.Property(e => e.UniEmailPrincipal)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("uni_email_principal");

                entity.Property(e => e.UniLogo)
                    .IsUnicode(false)
                    .HasColumnName("uni_logo");

                entity.Property(e => e.UniMunicipio).HasColumnName("uni_municipio");

                entity.Property(e => e.UniNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("uni_nombre");

                entity.Property(e => e.UniTelefonoPrincipal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("uni_telefono_principal");

                entity.HasOne(d => d.UniMunicipioNavigation)
                    .WithMany(p => p.InformacionUniversidads)
                    .HasForeignKey(d => d.UniMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Informacion_universidad_Departamento_municipio");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.Property(e => e.PaiId).HasColumnName("pai_id");

                entity.Property(e => e.PaiNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("pai_nombre");
            });

            modelBuilder.Entity<PaisDepartamento>(entity =>
            {
                entity.HasKey(e => e.DepId);

                entity.ToTable("Pais_departamento");

                entity.Property(e => e.DepId).HasColumnName("dep_id");

                entity.Property(e => e.DepCodigoDane)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("dep_codigo_dane");

                entity.Property(e => e.DepNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("dep_nombre");

                entity.Property(e => e.DepPais).HasColumnName("dep_pais");

                entity.HasOne(d => d.DepPaisNavigation)
                    .WithMany(p => p.PaisDepartamentos)
                    .HasForeignKey(d => d.DepPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pais_departamento_Pais");
            });

            modelBuilder.Entity<ProgramaCriterio>(entity =>
            {
                entity.HasKey(e => e.CriId);

                entity.ToTable("Programa_criterios");

                entity.Property(e => e.CriId).HasColumnName("cri_id");

                entity.Property(e => e.CriDescripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("cri_descripcion");

                entity.Property(e => e.CriNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("cri_nombre");

                entity.Property(e => e.CriPrograma).HasColumnName("cri_programa");

                entity.HasOne(d => d.CriProgramaNavigation)
                    .WithMany(p => p.ProgramaCriterios)
                    .HasForeignKey(d => d.CriPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programa_criterios_Sede_programa");
            });

            modelBuilder.Entity<SedePrograma>(entity =>
            {
                entity.HasKey(e => e.ProId);

                entity.ToTable("Sede_programa");

                entity.Property(e => e.ProId).HasColumnName("pro_id");

                entity.Property(e => e.ProNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("pro_nombre");

                entity.Property(e => e.ProSede).HasColumnName("pro_sede");

                entity.HasOne(d => d.ProSedeNavigation)
                    .WithMany(p => p.SedeProgramas)
                    .HasForeignKey(d => d.ProSede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sede_programa_Universidad_sede");
            });

            modelBuilder.Entity<SedeProgramaAspirante>(entity =>
            {
                entity.HasKey(e => e.AspId);

                entity.ToTable("Sede_programa_aspirante");

                entity.Property(e => e.AspId).HasColumnName("asp_id");

                entity.Property(e => e.AspApellidos)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("asp_apellidos");

                entity.Property(e => e.AspBarrio)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("asp_barrio");

                entity.Property(e => e.AspDireccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("asp_direccion");

                entity.Property(e => e.AspDni).HasColumnName("asp_dni");

                entity.Property(e => e.AspDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("asp_documento");

                entity.Property(e => e.AspFecha)
                    .HasColumnType("date")
                    .HasColumnName("asp_fecha");

                entity.Property(e => e.AspHora).HasColumnName("asp_hora");

                entity.Property(e => e.AspMunicipio).HasColumnName("asp_municipio");

                entity.Property(e => e.AspNombres)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("asp_nombres");

                entity.Property(e => e.AspNota1).HasColumnName("asp_nota1");

                entity.Property(e => e.AspNota2).HasColumnName("asp_nota2");

                entity.Property(e => e.AspNota3).HasColumnName("asp_nota3");

                entity.Property(e => e.AspNota4).HasColumnName("asp_nota4");

                entity.Property(e => e.AspNota5).HasColumnName("asp_nota5");

                entity.Property(e => e.AspPrograma).HasColumnName("asp_programa");

                entity.Property(e => e.AspSede).HasColumnName("asp_sede");

                entity.HasOne(d => d.AspDniNavigation)
                    .WithMany(p => p.SedeProgramaAspirantes)
                    .HasForeignKey(d => d.AspDni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sede_programa_aspirante_Dni_tipo");

                entity.HasOne(d => d.AspMunicipioNavigation)
                    .WithMany(p => p.SedeProgramaAspirantes)
                    .HasForeignKey(d => d.AspMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sede_programa_aspirante_Departamento_municipio");

                entity.HasOne(d => d.AspProgramaNavigation)
                    .WithMany(p => p.SedeProgramaAspirantes)
                    .HasForeignKey(d => d.AspPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sede_programa_aspirante_Sede_programa");

                entity.HasOne(d => d.AspSedeNavigation)
                    .WithMany(p => p.SedeProgramaAspirantes)
                    .HasForeignKey(d => d.AspSede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sede_programa_aspirante_Universidad_sede");
            });

            modelBuilder.Entity<SsoRol>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.ToTable("SSO_rol");

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.Property(e => e.RolDescripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("rol_descripcion");

                entity.Property(e => e.RolNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("rol_nombre");
            });

            modelBuilder.Entity<SsoUsuario>(entity =>
            {
                entity.HasKey(e => e.UsuId);

                entity.ToTable("SSO_usuario");

                entity.Property(e => e.UsuId).HasColumnName("usu_id");

                entity.Property(e => e.UsuApellido)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("usu_apellido");

                entity.Property(e => e.UsuClave)
                    .IsUnicode(false)
                    .HasColumnName("usu_clave");

                entity.Property(e => e.UsuDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("usu_documento");

                entity.Property(e => e.UsuEmail)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("usu_email");

                entity.Property(e => e.UsuNickname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("usu_nickname");

                entity.Property(e => e.UsuNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("usu_nombre");

                entity.Property(e => e.UsuRol).HasColumnName("usu_rol");

                entity.Property(e => e.UsuSede).HasColumnName("usu_sede");

                entity.Property(e => e.UsuUniversidad).HasColumnName("usu_universidad");

                entity.HasOne(d => d.UsuRolNavigation)
                    .WithMany(p => p.SsoUsuarios)
                    .HasForeignKey(d => d.UsuRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SSO_usuario_SSO_rol");

                entity.HasOne(d => d.UsuSedeNavigation)
                    .WithMany(p => p.SsoUsuarios)
                    .HasForeignKey(d => d.UsuSede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SSO_usuario_Universidad_sede");

                entity.HasOne(d => d.UsuUniversidadNavigation)
                    .WithMany(p => p.SsoUsuarios)
                    .HasForeignKey(d => d.UsuUniversidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SSO_usuario_Informacion_universidad");
            });

            modelBuilder.Entity<UniversidadSede>(entity =>
            {
                entity.HasKey(e => e.SedId);

                entity.ToTable("Universidad_sede");

                entity.Property(e => e.SedId).HasColumnName("sed_id");

                entity.Property(e => e.SedDireccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("sed_direccion");

                entity.Property(e => e.SedEmail)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("sed_email");

                entity.Property(e => e.SedNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("sed_nombre");

                entity.Property(e => e.SedTelefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sed_telefono");

                entity.Property(e => e.SedUniversidad).HasColumnName("sed_universidad");

                entity.HasOne(d => d.SedUniversidadNavigation)
                    .WithMany(p => p.UniversidadSedes)
                    .HasForeignKey(d => d.SedUniversidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Universidad_sede_Informacion_universidad");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
