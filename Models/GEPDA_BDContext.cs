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

        public virtual DbSet<AspiranteEntrevistum> AspiranteEntrevista { get; set; } = null!;
        public virtual DbSet<AspirantePrueba2> AspirantePrueba2s { get; set; } = null!;
        public virtual DbSet<AspirantePruebaIum> AspirantePruebaIa { get; set; } = null!;
        public virtual DbSet<DepartamentoMunicipio> DepartamentoMunicipios { get; set; } = null!;
        public virtual DbSet<DniTipo> DniTipos { get; set; } = null!;
        public virtual DbSet<Entrevistum> Entrevista { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<InformacionUniversidad> InformacionUniversidads { get; set; } = null!;
        public virtual DbSet<Pai> Pais { get; set; } = null!;
        public virtual DbSet<PaisDepartamento> PaisDepartamentos { get; set; } = null!;
        public virtual DbSet<Prueba2> Prueba2s { get; set; } = null!;
        public virtual DbSet<PruebaIum> PruebaIa { get; set; } = null!;
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
            modelBuilder.Entity<AspiranteEntrevistum>(entity =>
            {
                entity.ToTable("aspirante_entrevista");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaEntre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fecha_entre");

                entity.Property(e => e.IdAspirante).HasColumnName("id_aspirante");

                entity.Property(e => e.IdEntrevista).HasColumnName("id_entrevista");

                entity.Property(e => e.Nota).HasColumnName("nota");

                entity.HasOne(d => d.IdAspiranteNavigation)
                    .WithMany(p => p.AspiranteEntrevista)
                    .HasForeignKey(d => d.IdAspirante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_aspirante_entrevista_Sede_programa_aspirante");

                entity.HasOne(d => d.IdEntrevistaNavigation)
                    .WithMany(p => p.AspiranteEntrevista)
                    .HasForeignKey(d => d.IdEntrevista)
                    .HasConstraintName("FK_aspirante_entrevista_Entrevista");
            });

            modelBuilder.Entity<AspirantePrueba2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("aspirante_prueba2");

                entity.Property(e => e.IdAspirante).HasColumnName("id_aspirante");

                entity.Property(e => e.IdPruebaMate).HasColumnName("id_PruebaMate");

                entity.Property(e => e.Puntos).HasColumnName("puntos");

                entity.Property(e => e.Respuesta)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("respuesta");

                entity.HasOne(d => d.IdAspiranteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAspirante)
                    .HasConstraintName("FK_aspirante_pruebamate_Sede_programa_aspirante");

                entity.HasOne(d => d.IdPruebaMateNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPruebaMate)
                    .HasConstraintName("FK_aspirante_pruebamate_PruebaMatematicas");
            });

            modelBuilder.Entity<AspirantePruebaIum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("aspirante_PruebaIA");

                entity.Property(e => e.IdAspirante).HasColumnName("id_aspirante");

                entity.Property(e => e.IdPruebaIa).HasColumnName("id_pruebaIA");

                entity.Property(e => e.Puntos).HasColumnName("puntos");

                entity.Property(e => e.Respuesta)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("respuesta");

                entity.HasOne(d => d.IdAspiranteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAspirante)
                    .HasConstraintName("FK_aspirante_PruebaIA_Sede_programa_aspirante");

                entity.HasOne(d => d.IdPruebaIaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPruebaIa)
                    .HasConstraintName("FK_aspirante_PruebaIA_pruebaIA");
            });

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

            modelBuilder.Entity<Entrevistum>(entity =>
            {
                entity.HasKey(e => e.EntId);

                entity.Property(e => e.EntId).HasColumnName("ent_id");

                entity.Property(e => e.EntDescripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ent_descripcion");

                entity.Property(e => e.EntEstado).HasColumnName("ent_estado");

                entity.Property(e => e.EntNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ent_nombre");

                entity.Property(e => e.EntPrograma).HasColumnName("ent_programa");

                entity.Property(e => e.EntSede).HasColumnName("ent_sede");

                entity.Property(e => e.EntUniversidad).HasColumnName("ent_universidad");

                entity.HasOne(d => d.EntEstadoNavigation)
                    .WithMany(p => p.Entrevista)
                    .HasForeignKey(d => d.EntEstado)
                    .HasConstraintName("FK_Entrevista_Estado");

                entity.HasOne(d => d.EntProgramaNavigation)
                    .WithMany(p => p.Entrevista)
                    .HasForeignKey(d => d.EntPrograma)
                    .HasConstraintName("FK_Entrevista_Sede_programa");

                entity.HasOne(d => d.EntSedeNavigation)
                    .WithMany(p => p.Entrevista)
                    .HasForeignKey(d => d.EntSede)
                    .HasConstraintName("FK_Entrevista_Universidad_sede");

                entity.HasOne(d => d.EntUniversidadNavigation)
                    .WithMany(p => p.Entrevista)
                    .HasForeignKey(d => d.EntUniversidad)
                    .HasConstraintName("FK_Entrevista_Informacion_universidad");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.EstId);

                entity.ToTable("Estado");

                entity.Property(e => e.EstId).HasColumnName("est_id");

                entity.Property(e => e.EstNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("est_nombre");
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

                entity.Property(e => e.UniEstado).HasColumnName("uni_Estado");

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

                entity.HasOne(d => d.UniEstadoNavigation)
                    .WithMany(p => p.InformacionUniversidads)
                    .HasForeignKey(d => d.UniEstado)
                    .HasConstraintName("FK_Informacion_universidad_Estado");

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

            modelBuilder.Entity<Prueba2>(entity =>
            {
                entity.HasKey(e => e.PmId)
                    .HasName("PK_PruebaMatematicas");

                entity.ToTable("Prueba2");

                entity.Property(e => e.PmId).HasColumnName("pm_id");

                entity.Property(e => e.PmAudio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("pm_audio");

                entity.Property(e => e.PmEstado).HasColumnName("pm_estado");

                entity.Property(e => e.PmImagen)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("pm_imagen");

                entity.Property(e => e.PmOpcionA)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("pm_opcionA");

                entity.Property(e => e.PmOpcionB)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("pm_opcionB");

                entity.Property(e => e.PmOpcionC)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("pm_opcionC");

                entity.Property(e => e.PmOpcionD)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("pm_opcionD");

                entity.Property(e => e.PmPregunta)
                    .IsUnicode(false)
                    .HasColumnName("pm_pregunta");

                entity.Property(e => e.PmPrograma).HasColumnName("pm_programa");

                entity.Property(e => e.PmRespuesta)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("pm_respuesta");

                entity.Property(e => e.PmTexto)
                    .IsUnicode(false)
                    .HasColumnName("pm_texto");

                entity.Property(e => e.PmTitulo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("pm_titulo");

                entity.HasOne(d => d.PmEstadoNavigation)
                    .WithMany(p => p.Prueba2s)
                    .HasForeignKey(d => d.PmEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PruebaMatematicas_Estado");

                entity.HasOne(d => d.PmProgramaNavigation)
                    .WithMany(p => p.Prueba2s)
                    .HasForeignKey(d => d.PmPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prueba2_Sede_programa");
            });

            modelBuilder.Entity<PruebaIum>(entity =>
            {
                entity.HasKey(e => e.IaId);

                entity.ToTable("pruebaIA");

                entity.Property(e => e.IaId).HasColumnName("ia_id");

                entity.Property(e => e.IaAudio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ia_audio");

                entity.Property(e => e.IaEstado).HasColumnName("ia_estado");

                entity.Property(e => e.IaImagen)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ia_imagen");

                entity.Property(e => e.IaOpcionA)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ia_opcionA");

                entity.Property(e => e.IaOpcionB)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ia_opcionB");

                entity.Property(e => e.IaOpcionC)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ia_opcionC");

                entity.Property(e => e.IaOpcionD)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ia_opcionD");

                entity.Property(e => e.IaPregunta)
                    .IsUnicode(false)
                    .HasColumnName("ia_pregunta");

                entity.Property(e => e.IaRespuesta)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ia_respuesta");

                entity.Property(e => e.IaTexto)
                    .IsUnicode(false)
                    .HasColumnName("ia_texto");

                entity.Property(e => e.IaTitulo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ia_titulo");

                entity.Property(e => e.IaUniversidad).HasColumnName("ia_universidad");

                entity.HasOne(d => d.IaEstadoNavigation)
                    .WithMany(p => p.PruebaIa)
                    .HasForeignKey(d => d.IaEstado)
                    .HasConstraintName("FK_pruebaIA_Estado");

                entity.HasOne(d => d.IaUniversidadNavigation)
                    .WithMany(p => p.PruebaIa)
                    .HasForeignKey(d => d.IaUniversidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pruebaIA_Informacion_universidad");
            });

            modelBuilder.Entity<SedePrograma>(entity =>
            {
                entity.HasKey(e => e.ProId);

                entity.ToTable("Sede_programa");

                entity.Property(e => e.ProId).HasColumnName("pro_id");

                entity.Property(e => e.ProDescripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("pro_descripcion");

                entity.Property(e => e.ProEstado).HasColumnName("pro_estado");

                entity.Property(e => e.ProNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("pro_nombre");

                entity.Property(e => e.ProSede).HasColumnName("pro_sede");

                entity.Property(e => e.ProUniversidad).HasColumnName("pro_universidad");

                entity.HasOne(d => d.ProEstadoNavigation)
                    .WithMany(p => p.SedeProgramas)
                    .HasForeignKey(d => d.ProEstado)
                    .HasConstraintName("FK_Sede_programa_Estado");

                entity.HasOne(d => d.ProSedeNavigation)
                    .WithMany(p => p.SedeProgramas)
                    .HasForeignKey(d => d.ProSede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sede_programa_Universidad_sede");

                entity.HasOne(d => d.ProUniversidadNavigation)
                    .WithMany(p => p.SedeProgramas)
                    .HasForeignKey(d => d.ProUniversidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sede_programa_Informacion_universidad");
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

                entity.Property(e => e.AspEstado).HasColumnName("asp_Estado");

                entity.Property(e => e.AspMunicipio).HasColumnName("asp_municipio");

                entity.Property(e => e.AspNombres)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("asp_nombres");

                entity.Property(e => e.AspNotaFinal).HasColumnName("asp_notaFinal");

                entity.Property(e => e.AspPrograma).HasColumnName("asp_programa");

                entity.Property(e => e.AspPromedioEntrevista).HasColumnName("asp_promedioEntrevista");

                entity.Property(e => e.AspPromedioPrueba2).HasColumnName("asp_promedioPrueba2");

                entity.Property(e => e.AspPromedioPruebaIa).HasColumnName("asp_promedioPruebaIA");

                entity.Property(e => e.AspSede).HasColumnName("asp_sede");

                entity.Property(e => e.AspTelefono)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("asp_telefono");

                entity.Property(e => e.AspUniversidad).HasColumnName("asp_universidad");

                entity.HasOne(d => d.AspDniNavigation)
                    .WithMany(p => p.SedeProgramaAspirantes)
                    .HasForeignKey(d => d.AspDni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sede_programa_aspirante_Dni_tipo");

                entity.HasOne(d => d.AspEstadoNavigation)
                    .WithMany(p => p.SedeProgramaAspirantes)
                    .HasForeignKey(d => d.AspEstado)
                    .HasConstraintName("FK_Sede_programa_aspirante_Estado");

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

                entity.HasOne(d => d.AspUniversidadNavigation)
                    .WithMany(p => p.SedeProgramaAspirantes)
                    .HasForeignKey(d => d.AspUniversidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sede_programa_aspirante_Informacion_universidad");
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

                entity.Property(e => e.UsuEstado).HasColumnName("usu_estado");

                entity.Property(e => e.UsuNickname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("usu_nickname");

                entity.Property(e => e.UsuNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("usu_nombre");

                entity.Property(e => e.UsuPrograma).HasColumnName("usu_programa");

                entity.Property(e => e.UsuRol).HasColumnName("usu_rol");

                entity.Property(e => e.UsuSede).HasColumnName("usu_sede");

                entity.Property(e => e.UsuUniversidad).HasColumnName("usu_universidad");

                entity.HasOne(d => d.UsuEstadoNavigation)
                    .WithMany(p => p.SsoUsuarios)
                    .HasForeignKey(d => d.UsuEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SSO_usuario_Estado");

                entity.HasOne(d => d.UsuProgramaNavigation)
                    .WithMany(p => p.SsoUsuarios)
                    .HasForeignKey(d => d.UsuPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SSO_usuario_Sede_programa");

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

                entity.Property(e => e.SedEstado).HasColumnName("sed_estado");

                entity.Property(e => e.SedNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("sed_nombre");

                entity.Property(e => e.SedTelefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sed_telefono");

                entity.Property(e => e.SedUniversidad).HasColumnName("sed_universidad");

                entity.HasOne(d => d.SedEstadoNavigation)
                    .WithMany(p => p.UniversidadSedes)
                    .HasForeignKey(d => d.SedEstado)
                    .HasConstraintName("FK_Universidad_sede_Estado");

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
