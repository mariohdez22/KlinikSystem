using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KlinikSystem.Models;

public partial class KlinikSystemContext : DbContext
{
    public KlinikSystemContext()
    {
    }

    public KlinikSystemContext(DbContextOptions<KlinikSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AreaTrabajo> AreaTrabajos { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<DatoExaman> DatoExamen { get; set; }

    public virtual DbSet<DetalleDato> DetalleDatos { get; set; }

    public virtual DbSet<DetalleExaman> DetalleExamen { get; set; }

    public virtual DbSet<DetalleResultado> DetalleResultados { get; set; }

    public virtual DbSet<DetalleServicio> DetalleServicios { get; set; }

    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<EstadoCitum> EstadoCita { get; set; }

    public virtual DbSet<EstadoExpediente> EstadoExpedientes { get; set; }

    public virtual DbSet<EstadoLaboratorio> EstadoLaboratorios { get; set; }

    public virtual DbSet<EstadoPaciente> EstadoPacientes { get; set; }

    public virtual DbSet<EstadoPersonal> EstadoPersonals { get; set; }

    public virtual DbSet<Expediente> Expedientes { get; set; }

    public virtual DbSet<Laboratorio> Laboratorios { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<PruebaExaman> PruebaExamen { get; set; }

    public virtual DbSet<Recetum> Receta { get; set; }

    public virtual DbSet<RegistroExpediente> RegistroExpedientes { get; set; }

    public virtual DbSet<Resultado> Resultados { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TipoExaman> TipoExamen { get; set; }

    public virtual DbSet<TipoServicio> TipoServicios { get; set; }

    public virtual DbSet<Unidade> Unidades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AreaTrabajo>(entity =>
        {
            entity.HasKey(e => e.IdareaTrabajo).HasName("PK__area_tra__3AE0B6A8F803E6E5");

            entity.ToTable("area_trabajo");

            entity.Property(e => e.IdareaTrabajo).HasColumnName("idareaTrabajo");
            entity.Property(e => e.AreaTrabajo1)
                .IsUnicode(false)
                .HasColumnName("areaTrabajo");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.Idcitas).HasName("PK__citas__45E162B6B65B005C");

            entity.ToTable("citas");

            entity.Property(e => e.Idcitas).HasColumnName("idcitas");
            entity.Property(e => e.DuiPaciente)
                .IsUnicode(false)
                .HasColumnName("duiPaciente");
            entity.Property(e => e.EspecialidadPersonal)
                .IsUnicode(false)
                .HasColumnName("especialidadPersonal");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdestadoCita).HasColumnName("idestadoCita");
            entity.Property(e => e.IdmetodoPago).HasColumnName("idmetodoPago");
            entity.Property(e => e.Idpaciente).HasColumnName("idpaciente");
            entity.Property(e => e.Idpersonal).HasColumnName("idpersonal");
            entity.Property(e => e.NumCita)
                .IsUnicode(false)
                .HasColumnName("numCita");
            entity.Property(e => e.Precio)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IdestadoCitaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdestadoCita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__citas__idestadoC__5EBF139D");

            entity.HasOne(d => d.IdmetodoPagoNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdmetodoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__citas__idmetodoP__5FB337D6");

            entity.HasOne(d => d.IdpacienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.Idpaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__citas__idpacient__5CD6CB2B");

            entity.HasOne(d => d.IdpersonalNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.Idpersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__citas__idpersona__5DCAEF64");
        });

        modelBuilder.Entity<DatoExaman>(entity =>
        {
            entity.HasKey(e => e.IddatoExamen).HasName("PK__dato_exa__59557762515E5ADB");

            entity.ToTable("dato_examen");

            entity.Property(e => e.IddatoExamen).HasColumnName("iddatoExamen");
            entity.Property(e => e.Dato)
                .IsUnicode(false)
                .HasColumnName("dato");
            entity.Property(e => e.IdpruebaExamen).HasColumnName("idpruebaExamen");

            entity.HasOne(d => d.IdpruebaExamenNavigation).WithMany(p => p.DatoExamen)
                .HasForeignKey(d => d.IdpruebaExamen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__dato_exam__idpru__02084FDA");
        });

        modelBuilder.Entity<DetalleDato>(entity =>
        {
            entity.HasKey(e => e.IddetalleDatos).HasName("PK__detalle___E136BD66EC6CB393");

            entity.ToTable("detalle_datos");

            entity.Property(e => e.IddetalleDatos).HasColumnName("iddetalleDatos");
            entity.Property(e => e.IddatoExamen).HasColumnName("iddatoExamen");
            entity.Property(e => e.IddetalleExamen).HasColumnName("iddetalleExamen");
            entity.Property(e => e.Precio)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IddatoExamenNavigation).WithMany(p => p.DetalleDatos)
                .HasForeignKey(d => d.IddatoExamen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_d__iddat__09A971A2");

            entity.HasOne(d => d.IddetalleExamenNavigation).WithMany(p => p.DetalleDatos)
                .HasForeignKey(d => d.IddetalleExamen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_d__iddet__08B54D69");
        });

        modelBuilder.Entity<DetalleExaman>(entity =>
        {
            entity.HasKey(e => e.IddetalleExamen).HasName("PK__detalle___3B0B5CE1FA969774");

            entity.ToTable("detalle_examen");

            entity.Property(e => e.IddetalleExamen).HasColumnName("iddetalleExamen");
            entity.Property(e => e.CodigoDetalle)
                .IsUnicode(false)
                .HasColumnName("codigoDetalle");
            entity.Property(e => e.Idlaboratorio).HasColumnName("idlaboratorio");
            entity.Property(e => e.IdpruebaExamen).HasColumnName("idpruebaExamen");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");

            entity.HasOne(d => d.IdlaboratorioNavigation).WithMany(p => p.DetalleExamen)
                .HasForeignKey(d => d.Idlaboratorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_e__idlab__04E4BC85");

            entity.HasOne(d => d.IdpruebaExamenNavigation).WithMany(p => p.DetalleExamen)
                .HasForeignKey(d => d.IdpruebaExamen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_e__idpru__05D8E0BE");
        });

        modelBuilder.Entity<DetalleResultado>(entity =>
        {
            entity.HasKey(e => e.IddetalleResultados).HasName("PK__detalle___6CED11000E92D183");

            entity.ToTable("detalle_resultados");

            entity.Property(e => e.IddetalleResultados).HasColumnName("iddetalleResultados");
            entity.Property(e => e.IddatosExamen).HasColumnName("iddatosExamen");
            entity.Property(e => e.Idresultados).HasColumnName("idresultados");
            entity.Property(e => e.Idunidades).HasColumnName("idunidades");
            entity.Property(e => e.RangoReferencia)
                .IsUnicode(false)
                .HasColumnName("rangoReferencia");
            entity.Property(e => e.Resultado)
                .IsUnicode(false)
                .HasColumnName("resultado");

            entity.HasOne(d => d.IddatosExamenNavigation).WithMany(p => p.DetalleResultados)
                .HasForeignKey(d => d.IddatosExamen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_r__iddat__123EB7A3");

            entity.HasOne(d => d.IdresultadosNavigation).WithMany(p => p.DetalleResultados)
                .HasForeignKey(d => d.Idresultados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_r__idres__114A936A");

            entity.HasOne(d => d.IdunidadesNavigation).WithMany(p => p.DetalleResultados)
                .HasForeignKey(d => d.Idunidades)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_r__iduni__1332DBDC");
        });

        modelBuilder.Entity<DetalleServicio>(entity =>
        {
            entity.HasKey(e => e.IddetalleServicios).HasName("PK__detalle___CF2DB51B23A0594F");

            entity.ToTable("detalle_servicios");

            entity.Property(e => e.IddetalleServicios).HasColumnName("iddetalleServicios");
            entity.Property(e => e.Idservicios).HasColumnName("idservicios");
            entity.Property(e => e.IdtipoServicio).HasColumnName("idtipoServicio");
            entity.Property(e => e.Precio)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Resultado)
                .IsUnicode(false)
                .HasColumnName("resultado");

            entity.HasOne(d => d.IdserviciosNavigation).WithMany(p => p.DetalleServicios)
                .HasForeignKey(d => d.Idservicios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_s__idser__73BA3083");

            entity.HasOne(d => d.IdtipoServicioNavigation).WithMany(p => p.DetalleServicios)
                .HasForeignKey(d => d.IdtipoServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_s__idtip__74AE54BC");
        });

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.Idespecialidad).HasName("PK__especial__9095F632B1C9297A");

            entity.ToTable("especialidades");

            entity.Property(e => e.Idespecialidad).HasColumnName("idespecialidad");
            entity.Property(e => e.Especialidad)
                .IsUnicode(false)
                .HasColumnName("especialidad");
        });

        modelBuilder.Entity<EstadoCitum>(entity =>
        {
            entity.HasKey(e => e.IdestadoCita).HasName("PK__estado_c__0E34C551085F9EA3");

            entity.ToTable("estado_cita");

            entity.Property(e => e.IdestadoCita).HasColumnName("idestadoCita");
            entity.Property(e => e.EstadoCita)
                .IsUnicode(false)
                .HasColumnName("estadoCita");
        });

        modelBuilder.Entity<EstadoExpediente>(entity =>
        {
            entity.HasKey(e => e.IdestadoExpediente).HasName("PK__estado_e__1BA4D9547C37579D");

            entity.ToTable("estado_expediente");

            entity.Property(e => e.IdestadoExpediente).HasColumnName("idestadoExpediente");
            entity.Property(e => e.EstadoExpediente1)
                .IsUnicode(false)
                .HasColumnName("estadoExpediente");
        });

        modelBuilder.Entity<EstadoLaboratorio>(entity =>
        {
            entity.HasKey(e => e.IdestadoLaboratorio).HasName("PK__estado_l__E4692FBAF96D459B");

            entity.ToTable("estado_laboratorio");

            entity.Property(e => e.IdestadoLaboratorio).HasColumnName("idestadoLaboratorio");
            entity.Property(e => e.EstadoLaboratorio1)
                .IsUnicode(false)
                .HasColumnName("estadoLaboratorio");
        });

        modelBuilder.Entity<EstadoPaciente>(entity =>
        {
            entity.HasKey(e => e.IdestadoPaciente).HasName("PK__estado_p__920EECF588299F43");

            entity.ToTable("estado_paciente");

            entity.Property(e => e.IdestadoPaciente).HasColumnName("idestadoPaciente");
            entity.Property(e => e.EstadoPaciente1)
                .IsUnicode(false)
                .HasColumnName("estadoPaciente");
        });

        modelBuilder.Entity<EstadoPersonal>(entity =>
        {
            entity.HasKey(e => e.IdestadoPersonal).HasName("PK__estado_p__D22ECD2A65F1A85D");

            entity.ToTable("estado_personal");

            entity.Property(e => e.IdestadoPersonal).HasColumnName("idestadoPersonal");
            entity.Property(e => e.EstadoPersonal1)
                .IsUnicode(false)
                .HasColumnName("estadoPersonal");
        });

        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.Idexpediente).HasName("PK__expedien__E0C4C42A9659273C");

            entity.ToTable("expediente");

            entity.Property(e => e.Idexpediente).HasColumnName("idexpediente");
            entity.Property(e => e.Alergias)
                .IsUnicode(false)
                .HasColumnName("alergias");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.IdestadoExpediente).HasColumnName("idestadoExpediente");
            entity.Property(e => e.Idpaciente).HasColumnName("idpaciente");
            entity.Property(e => e.Idpersonal).HasColumnName("idpersonal");
            entity.Property(e => e.NumeroExpediente)
                .IsUnicode(false)
                .HasColumnName("numeroExpediente");

            entity.HasOne(d => d.IdestadoExpedienteNavigation).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.IdestadoExpediente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__expedient__idest__66603565");

            entity.HasOne(d => d.IdpacienteNavigation).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.Idpaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__expedient__idpac__6477ECF3");

            entity.HasOne(d => d.IdpersonalNavigation).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.Idpersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__expedient__idper__656C112C");
        });

        modelBuilder.Entity<Laboratorio>(entity =>
        {
            entity.HasKey(e => e.Idlaboratorio).HasName("PK__laborato__85A2EA9EF8E3914F");

            entity.ToTable("laboratorio");

            entity.Property(e => e.Idlaboratorio).HasColumnName("idlaboratorio");
            entity.Property(e => e.CodigoLaboratorio)
                .IsUnicode(false)
                .HasColumnName("codigoLaboratorio");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdestadoLaboratorio).HasColumnName("idestadoLaboratorio");
            entity.Property(e => e.Idexpediente).HasColumnName("idexpediente");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.TipoSangre)
                .IsUnicode(false)
                .HasColumnName("tipoSangre");
            entity.Property(e => e.Total)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdestadoLaboratorioNavigation).WithMany(p => p.Laboratorios)
                .HasForeignKey(d => d.IdestadoLaboratorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__laborator__idest__7A672E12");

            entity.HasOne(d => d.IdexpedienteNavigation).WithMany(p => p.Laboratorios)
                .HasForeignKey(d => d.Idexpediente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__laborator__idexp__797309D9");
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.IdmetodoPago).HasName("PK__metodo_p__0542DBF887CFB849");

            entity.ToTable("metodo_pago");

            entity.Property(e => e.IdmetodoPago).HasColumnName("idmetodoPago");
            entity.Property(e => e.MetodoPago1)
                .IsUnicode(false)
                .HasColumnName("metodoPago");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Idpaciente).HasName("PK__paciente__58611A0A1ABA9CF9");

            entity.ToTable("pacientes");

            entity.Property(e => e.Idpaciente).HasColumnName("idpaciente");
            entity.Property(e => e.Celular)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.Contrasena)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Correo)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Dui)
                .IsUnicode(false)
                .HasColumnName("dui");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.IdestadoPaciente).HasColumnName("idestadoPaciente");
            entity.Property(e => e.Nombre)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdestadoPacienteNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdestadoPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pacientes__idest__5629CD9C");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.Idpersonal).HasName("PK__personal__DFD00B3E380AD041");

            entity.ToTable("personal");

            entity.Property(e => e.Idpersonal).HasColumnName("idpersonal");
            entity.Property(e => e.Celular)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.Contrasena)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Correo)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Dui)
                .IsUnicode(false)
                .HasColumnName("dui");
            entity.Property(e => e.IdareaTrabajo).HasColumnName("idareaTrabajo");
            entity.Property(e => e.Idespecialidad).HasColumnName("idespecialidad");
            entity.Property(e => e.IdestadoPersonal).HasColumnName("idestadoPersonal");
            entity.Property(e => e.Imagen)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombres)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Profecion)
                .IsUnicode(false)
                .HasColumnName("profecion");

            entity.HasOne(d => d.IdareaTrabajoNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdareaTrabajo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__personal__idarea__4F7CD00D");

            entity.HasOne(d => d.IdespecialidadNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.Idespecialidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__personal__idespe__5070F446");

            entity.HasOne(d => d.IdestadoPersonalNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdestadoPersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__personal__idesta__5165187F");
        });

        modelBuilder.Entity<PruebaExaman>(entity =>
        {
            entity.HasKey(e => e.IdpruebaExamen).HasName("PK__prueba_e__8150777EEC9A0B92");

            entity.ToTable("prueba_examen");

            entity.Property(e => e.IdpruebaExamen).HasColumnName("idpruebaExamen");
            entity.Property(e => e.IdtipoExamen).HasColumnName("idtipoExamen");
            entity.Property(e => e.NombrePrueba)
                .IsUnicode(false)
                .HasColumnName("nombrePrueba");
            entity.Property(e => e.Precio)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IdtipoExamenNavigation).WithMany(p => p.PruebaExamen)
                .HasForeignKey(d => d.IdtipoExamen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__prueba_ex__idtip__7F2BE32F");
        });

        modelBuilder.Entity<Recetum>(entity =>
        {
            entity.HasKey(e => e.Idreceta).HasName("PK__receta__840286EF0B9AD30F");

            entity.ToTable("receta");

            entity.Property(e => e.Idreceta).HasColumnName("idreceta");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodigoReceta)
                .IsUnicode(false)
                .HasColumnName("codigoReceta");
            entity.Property(e => e.DuracionTratamiento)
                .IsUnicode(false)
                .HasColumnName("duracionTratamiento");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Idexpediente).HasColumnName("idexpediente");
            entity.Property(e => e.Indicaciones)
                .IsUnicode(false)
                .HasColumnName("indicaciones");
            entity.Property(e => e.Medicamento)
                .IsUnicode(false)
                .HasColumnName("medicamento");

            entity.HasOne(d => d.IdexpedienteNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.Idexpediente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__receta__idexpedi__6C190EBB");
        });

        modelBuilder.Entity<RegistroExpediente>(entity =>
        {
            entity.HasKey(e => e.IdregistroExpediente).HasName("PK__registro__8B061102D28CC66C");

            entity.ToTable("registro_expediente");

            entity.Property(e => e.IdregistroExpediente).HasColumnName("idregistroExpediente");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.GravedadAsunto)
                .IsUnicode(false)
                .HasColumnName("gravedadAsunto");
            entity.Property(e => e.Idexpediente).HasColumnName("idexpediente");
            entity.Property(e => e.MotivoVisita)
                .IsUnicode(false)
                .HasColumnName("motivoVisita");
            entity.Property(e => e.Sintomas)
                .IsUnicode(false)
                .HasColumnName("sintomas");

            entity.HasOne(d => d.IdexpedienteNavigation).WithMany(p => p.RegistroExpedientes)
                .HasForeignKey(d => d.Idexpediente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__registro___idexp__693CA210");
        });

        modelBuilder.Entity<Resultado>(entity =>
        {
            entity.HasKey(e => e.Idresultados).HasName("PK__resultad__62BFC45E8E2368DD");

            entity.ToTable("resultados");

            entity.Property(e => e.Idresultados).HasColumnName("idresultados");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IddetalleExamen).HasColumnName("iddetalleExamen");
            entity.Property(e => e.Observaciones)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.Paciente)
                .IsUnicode(false)
                .HasColumnName("paciente");

            entity.HasOne(d => d.IddetalleExamenNavigation).WithMany(p => p.Resultados)
                .HasForeignKey(d => d.IddetalleExamen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__resultado__iddet__0E6E26BF");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Idservicios).HasName("PK__servicio__99C2027874B9DA11");

            entity.ToTable("servicios");

            entity.Property(e => e.Idservicios).HasColumnName("idservicios");
            entity.Property(e => e.CodigoServicio)
                .IsUnicode(false)
                .HasColumnName("codigoServicio");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Idexpediente).HasColumnName("idexpediente");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdexpedienteNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.Idexpediente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__servicios__idexp__6EF57B66");
        });

        modelBuilder.Entity<TipoExaman>(entity =>
        {
            entity.HasKey(e => e.IdtipoExamen).HasName("PK__tipo_exa__E51071FFD825DB54");

            entity.ToTable("tipo_examen");

            entity.Property(e => e.IdtipoExamen).HasColumnName("idtipoExamen");
            entity.Property(e => e.TipoExamen)
                .IsUnicode(false)
                .HasColumnName("tipoExamen");
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.HasKey(e => e.IdtipoServicio).HasName("PK__tipo_ser__419196A8F6A11DFA");

            entity.ToTable("tipo_servicio");

            entity.Property(e => e.IdtipoServicio).HasColumnName("idtipoServicio");
            entity.Property(e => e.TipoServicio1)
                .IsUnicode(false)
                .HasColumnName("tipoServicio");
        });

        modelBuilder.Entity<Unidade>(entity =>
        {
            entity.HasKey(e => e.Idunidades).HasName("PK__unidades__C96D98B73980C159");

            entity.ToTable("unidades");

            entity.Property(e => e.Idunidades).HasColumnName("idunidades");
            entity.Property(e => e.Unidad)
                .IsUnicode(false)
                .HasColumnName("unidad");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
