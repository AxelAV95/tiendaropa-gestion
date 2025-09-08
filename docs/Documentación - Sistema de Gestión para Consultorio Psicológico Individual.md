# Sistema de Gestión para Consultorio Psicológico Individual

## 1. ANÁLISIS SIMPLIFICADO

### 1.1 Descripción del Sistema

Sistema web sencillo para un psicólogo independiente que busca digitalizar la gestión de su consultorio, enfocándose en lo esencial: pacientes, citas e historiales básicos.

### 1.2 Objetivos Principales

- Reemplazar agenda física por un calendario digital.
- Centralizar la información básica de los pacientes.
- Llevar un historial seguro de notas de sesión.
- Automatizar recordatorios de citas.
- Generar reportes simples de actividad.

### 1.3 Usuarios

- **Psicólogo**: Usuario principal y único administrador.
- **Asistente** (opcional): Con permisos limitados para programar citas.

## 2. MÓDULOS DEL SISTEMA

### 2.1 Microservicio de Autenticación y Gestión de Usuarios (Spring Boot)

Este es un componente independiente. Se encarga de la seguridad y los usuarios.

- **Funcionalidades**:
  - Registro de usuarios.
  - Autenticación con email/contraseña.
  - Recuperación y cambio de contraseña.
  - Gestión de roles de usuario (Psicólogo, Asistente).
  - Revocación de tokens de acceso.
- **Tecnologías**: Spring Boot, Spring Security, JWT (JSON Web Tokens), Base de Datos.

### 2.2 Módulo de Gestión de Pacientes

Permite el manejo de la información de los pacientes.

- **Funcionalidades**:
  - Registro, edición y búsqueda de pacientes.
  - Historial de pacientes y notas.
  - Estados: activo/inactivo.

### 2.3 Módulo de Agenda y Citas

Ofrece una vista de calendario para gestionar las citas.

- **Funcionalidades**:
  - Crear, editar y cancelar citas.
  - Calendario semanal y mensual.
  - Detección de conflictos de horario.
  - Notificación automática de creación de cita.

### 2.4 Módulo de Notas de Sesión

Permite crear y gestionar notas confidenciales.

- **Funcionalidades**:
  - Crear notas de sesión asociadas a cada cita.
  - Historial cronológico de notas por paciente.

### 2.5 Módulo de Reportes

Genera reportes de actividad para el consultorio.

- **Funcionalidades**:
  - Reportes de citas y pacientes.
  - Exportación de reportes a PDF.

### 2.6 Módulo de Notificaciones Automáticas

Microservicio o proceso programado encargado de enviar recordatorios.

- **Funcionalidades**:
  - Envío de confirmación de cita al paciente.
  - Envío de recordatorio antes de la cita.
- **Tecnologías**: Spring Boot, Spring Scheduling, JavaMailSender, Base de Datos.

## 3. REQUERIMIENTOS FUNCIONALES DETALLADOS

### 3.1 Módulo de Autenticación y Usuarios (Microservicio)

- **RF-01**: Como usuario, quiero registrarme con email y contraseña.
- **RF-02**: Como usuario, quiero iniciar sesión con mis credenciales.
- **RF-03**: Como usuario, quiero solicitar un enlace para restablecer mi contraseña por email.
- **RF-04**: Como usuario, quiero cambiar mi contraseña actual.
- **RF-05**: El sistema debe manejar dos roles: "Psicólogo" (rol por defecto) y "Asistente".
- **RF-06**: El sistema debe generar un token JWT tras el inicio de sesión para la autenticación en otros módulos.
- **RF-07**: El sistema debe revocar los tokens de acceso al cerrar sesión.

### 3.2 Módulo de Gestión de Pacientes

- **RF-08**: Registrar un paciente con campos obligatorios: nombre, apellidos, teléfono y fecha de nacimiento.
- **RF-09**: El sistema debe validar que no existan pacientes duplicados por nombre y teléfono.
- **RF-10**: El sistema debe permitir editar la información de un paciente.
- **RF-11**: El sistema debe permitir buscar pacientes por nombre o apellidos.
- **RF-12**: El sistema debe mostrar una lista de todos los pacientes, con opción de filtro por estado (activo/inactivo).
- **RF-13**: El sistema debe mostrar el historial completo de un paciente, incluyendo citas y notas de sesión.

### 3.3 Módulo de Agenda y Citas

- **RF-14**: El sistema debe permitir crear una cita seleccionando un paciente, fecha, hora y duración.
- **RF-15**: El sistema debe validar que no haya superposición de citas para el mismo psicólogo.
- **RF-16**: El sistema debe mostrar un calendario con vistas semanal y mensual.
- **RF-17**: El sistema debe permitir editar o reprogramar citas existentes.
- **RF-18**: El sistema debe permitir cancelar citas.
- **RF-19**: El sistema debe marcar citas como "realizadas" o "no asistió".

### 3.4 Módulo de Notas de Sesión

- **RF-20**: El sistema debe permitir crear una nota de sesión después de que una cita haya sido marcada como "realizada".
- **RF-21**: El sistema debe asociar la nota a la cita y al paciente.
- **RF-22**: El sistema debe permitir editar notas de sesiones anteriores.
- **RF-23**: El sistema debe permitir buscar en el contenido de las notas de un paciente.

### 3.5 Módulo de Reportes

- **RF-24**: El sistema debe generar reportes de citas por período (mes, semana).
- **RF-25**: El sistema debe generar un reporte de pacientes activos.
- **RF-26**: El sistema debe exportar los reportes a formato PDF.

### 3.6 Módulo de Notificaciones

- **RF-27**: El sistema debe enviar una notificación de confirmación por email al paciente al crear una nueva cita.
- **RF-28**: El sistema debe enviar un recordatorio por email al paciente 24 horas antes de la cita programada.
- **RF-29**: El sistema debe registrar en la base de datos el estado de envío de cada notificación.

## 4. REQUERIMIENTOS NO FUNCIONALES

- **RNF-01**: **Seguridad**: El login debe ser seguro, las contraseñas cifradas y los datos de paciente deben estar protegidos por HTTPS.
- **RNF-02**: **Usabilidad**: La interfaz debe ser intuitiva y el sistema debe ser "responsive" para usarse en dispositivos móviles y tabletas.
- **RNF-03**: **Rendimiento**: La carga de las pantallas principales debe ser menor a 3 segundos.
- **RNF-04**: **Disponibilidad**: El sistema debe tener un tiempo de actividad del 99%.
- **RNF-05**: **Arquitectura**: Los módulos de autenticación y notificaciones deben ser microservicios independientes, que los otros módulos consuman a través de una API REST.

## 5. CASOS DE USO COMPLETOS

### 5.1 CU-001: Registro de Usuario (Microservicio de Autenticación)

- **Actor**: Psicólogo.
- **Precondiciones**: El usuario no existe en la base de datos.
- **Flujo Principal**:
  1. El usuario accede a la página de registro.
  2. El sistema muestra un formulario con campos para nombre, email y contraseña.
  3. El usuario ingresa sus datos y hace clic en "Registrarse".
  4. El frontend envía la solicitud al microservicio de autenticación.
  5. El microservicio valida los datos, cifra la contraseña y la guarda en la base de datos.
  6. Si es exitoso, devuelve una respuesta con el nuevo usuario registrado.
- **Flujos Alternativos**:
  - **A1 - Email ya registrado**: El microservicio devuelve un error indicando que el email ya está en uso. El frontend muestra un mensaje de error.
- **Postcondiciones**: Un nuevo usuario es creado con el rol "Psicólogo" y puede iniciar sesión.

### 5.2 CU-002: Autenticación de Usuario (LOGIN)

- **Actor**: Psicólogo o Asistente.
- **Precondiciones**: El usuario está registrado en el sistema.
- **Flujo Principal**:
  1. El usuario accede a la página de login.
  2. El sistema muestra un formulario con campos para email y contraseña.
  3. El usuario ingresa sus credenciales y hace clic en "Iniciar Sesión".
  4. El sistema envía las credenciales al microservicio de autenticación.
  5. El microservicio valida las credenciales. Si son correctas, genera un token JWT.
  6. El microservicio devuelve el token al frontend.
  7. El frontend almacena el token de forma segura (e.g., en memoria o cookies HTTP-only).
  8. El frontend redirige al usuario al dashboard.
- **Flujos Alternativos**:
  - **A1 - Credenciales incorrectas**: El microservicio devuelve un error 401. El frontend muestra un mensaje de error "Email o contraseña incorrectos".
- **Postcondiciones**: El usuario está autenticado y puede acceder a los recursos protegidos.

### 5.3 CU-003: Programar Cita Nueva

- **Actor**: Psicólogo.
- **Precondiciones**: El psicólogo está autenticado. Al menos un paciente registrado.
- **Flujo Principal**:
  1. El psicólogo accede al calendario.
  2. Hace clic en un horario libre. El sistema muestra un modal para crear una cita.
  3. El psicólogo busca y selecciona un paciente de la lista.
  4. El psicólogo selecciona la fecha, hora y duración de la cita.
  5. El frontend envía la solicitud de creación de cita al backend, incluyendo el token JWT en la cabecera.
  6. El backend valida el token y verifica los permisos del usuario.
  7. El backend valida la disponibilidad del horario.
  8. Si no hay conflictos, guarda la cita en la base de datos.
  9. El backend devuelve una respuesta de éxito.
  10. El sistema actualiza el calendario con la nueva cita y activa el proceso para enviar una notificación de confirmación al paciente.
- **Flujos Alternativos**:
  - **A1 - Conflicto de horario**: El backend devuelve un error con un mensaje descriptivo. El frontend muestra un mensaje de error y sugiere horarios alternativos.
  - **A2 - Token no válido**: El backend devuelve un error 401. El frontend redirige al usuario a la página de login.

### 5.4 CU-004: Editar y Reprogramar Cita

- **Actor**: Psicólogo.
- **Precondiciones**: Existe una cita programada.
- **Flujo Principal**:
  1. El psicólogo navega al calendario y selecciona una cita existente.
  2. El sistema muestra un modal con los detalles de la cita y la opción "Editar".
  3. El psicólogo cambia la fecha y/o la hora de la cita.
  4. El frontend envía la solicitud de actualización al backend.
  5. El backend valida la nueva disponibilidad del horario.
  6. Si el cambio es válido, actualiza la cita y notifica el cambio al paciente.
- **Flujos Alternativos**:
  - **A1 - Horario no disponible**: El backend rechaza la solicitud y el frontend muestra un error.
- **Postcondiciones**: La cita se actualiza en el calendario y el paciente es notificado.

### 5.5 CU-005: Registrar Paciente Nuevo

- **Actor**: Psicólogo.
- **Precondiciones**: El psicólogo está autenticado.
- **Flujo Principal**:
  1. El psicólogo accede al módulo de pacientes.
  2. Hace clic en "Nuevo Paciente". El sistema muestra un formulario.
  3. El psicólogo completa los datos obligatorios del paciente.
  4. El frontend envía la solicitud de registro al backend con el token JWT.
  5. El backend valida el token y los permisos.
  6. El backend valida que no exista un paciente con el mismo nombre y teléfono.
  7. Si las validaciones son correctas, el backend guarda el nuevo paciente.
  8. El backend devuelve una respuesta de éxito.
  9. El sistema redirige al psicólogo a la lista de pacientes, mostrando el nuevo registro.
- **Flujos Alternativos**:
  - **A1 - Datos inválidos**: El backend devuelve un error de validación. El frontend muestra los errores correspondientes en el formulario.
  - **A2 - Paciente duplicado**: El backend devuelve un error de conflicto. El frontend muestra un mensaje de advertencia y permite al usuario confirmar si desea registrarlo de todos modos o si es un error.

### 5.6 CU-006: Editar Información de Paciente

- **Actor**: Psicólogo.
- **Precondiciones**: El paciente ya está registrado.
- **Flujo Principal**:
  1. El psicólogo navega a la lista de pacientes.
  2. Busca al paciente deseado y hace clic en "Editar".
  3. El sistema muestra un formulario con la información actual del paciente.
  4. El psicólogo modifica los campos necesarios (e.g., teléfono, email).
  5. El frontend envía la solicitud de actualización al backend.
  6. El backend valida la solicitud y actualiza la información del paciente.
- **Flujos Alternativos**:
  - **A1 - Datos incorrectos**: El backend rechaza la actualización si los datos son inválidos.
- **Postcondiciones**: La información del paciente se actualiza en la base de datos.

### 5.7 CU-007: Buscar y Ver Historial de Paciente

- **Actor**: Psicólogo.
- **Precondiciones**: Al menos un paciente con historial.
- **Flujo Principal**:
  1. El psicólogo accede al módulo de pacientes.
  2. En el campo de búsqueda, ingresa el nombre del paciente.
  3. El sistema filtra la lista de pacientes en tiempo real.
  4. El psicólogo selecciona al paciente de los resultados.
  5. El sistema muestra la página de detalles del paciente, incluyendo sus datos básicos y un historial cronológico de citas y notas de sesión.
- **Flujos Alternativos**:
  - **A1 - Sin resultados**: El sistema muestra un mensaje de "No se encontraron pacientes".
- **Postcondiciones**: El psicólogo puede visualizar toda la información y el historial del paciente.

### 5.8 CU-008: Registrar Nota de Sesión

- **Actor**: Psicólogo.
- **Precondiciones**: Una cita ha sido marcada como "realizada".
- **Flujo Principal**:
  1. El psicólogo accede a la cita marcada como "realizada".
  2. Hace clic en el botón "Agregar Nota".
  3. El sistema muestra un formulario para la nota.
  4. El psicólogo escribe el contenido de la nota.
  5. El frontend envía la nota al backend con el token JWT.
  6. El backend valida el token y guarda la nota en la base de datos, asociándola a la cita y al paciente.
  7. El backend devuelve una respuesta de éxito.
  8. La cita ahora muestra un ícono de que tiene una nota asociada.
- **Flujos Alternativos**:
  - **A1 - Cita no realizada**: El sistema no muestra la opción "Agregar Nota" hasta que la cita sea marcada como "realizada".

### 5.9 CU-009: Editar Nota de Sesión Existente

- **Actor**: Psicólogo.
- **Precondiciones**: Ya existe una nota de sesión.
- **Flujo Principal**:
  1. El psicólogo accede al historial del paciente.
  2. Localiza la nota de sesión que desea editar y hace clic en "Editar".
  3. El sistema muestra el contenido actual de la nota en un formulario editable.
  4. El psicólogo realiza los cambios necesarios y hace clic en "Guardar".
  5. El frontend envía la solicitud al backend.
  6. El backend valida y actualiza el contenido de la nota en la base de datos.
- **Postcondiciones**: La nota de sesión queda actualizada.

### 5.10 CU-010: Generar Reporte Mensual

- **Actor**: Psicólogo.
- **Precondiciones**: El psicólogo está autenticado y hay datos registrados.
- **Flujo Principal**:
  1. El psicólogo accede al módulo de reportes.
  2. Selecciona "Reporte Mensual" y elige el mes y año deseados.
  3. El frontend envía la solicitud de reporte al backend.
  4. El backend, a través de sus servicios, consulta la información de citas y pacientes para ese período.
  5. El backend procesa los datos y genera el reporte.
  6. El backend devuelve los datos del reporte al frontend.
  7. El frontend renderiza el reporte en la pantalla, permitiendo la opción de "Exportar a PDF".
- **Flujos Alternativos**:
  - **A1 - Sin datos**: Si no hay datos para el período, el sistema muestra un mensaje informativo "No hay datos para generar el reporte en este período".

### 5.11 CU-011: Envío de Confirmación de Cita (Microservicio de Notificaciones)

- **Actor**: Sistema (proceso automatizado).
- **Precondiciones**: Se ha creado una nueva cita en el sistema.
- **Flujo Principal**:
  1. La API principal, al guardar una nueva cita, envía un evento al microservicio de notificaciones.
  2. El microservicio de notificaciones recibe el evento y recupera la información de la cita y del paciente (nombre, email, fecha y hora).
  3. El microservicio utiliza el servicio de email para componer y enviar un correo de confirmación al paciente, informando de los detalles de la cita.
  4. El microservicio registra que la notificación de confirmación ha sido enviada con éxito.
- **Postcondiciones**: El paciente recibe un correo de confirmación de su cita.

### 5.12 CU-012: Envío de Recordatorio Previo a la Cita (Microservicio de Notificaciones)

- **Actor**: Sistema (proceso programado).
- **Precondiciones**: Existe una cita programada para las próximas 24 horas y el recordatorio aún no ha sido enviado.
- **Flujo Principal**:
  1. El microservicio de notificaciones ejecuta una tarea programada diariamente (e.g., a medianoche).
  2. El microservicio consulta la base de datos para encontrar citas que cumplan la condición de "próximas 24 horas" y "recordatorio no enviado".
  3. Por cada cita encontrada, el microservicio recupera la información del paciente (nombre, email) y los detalles de la cita (fecha, hora).
  4. El microservicio utiliza el servicio de email (e.g., `JavaMailSender`) para componer y enviar un correo de recordatorio al paciente, recordándole la próxima cita.
  5. Si el envío es exitoso, el microservicio actualiza el estado de la cita en la base de datos para marcar el recordatorio como "enviado".
- **Flujos Alternativos**:
  - **A1 - Falla de envío**: Si el email no se puede enviar (e.g., email inválido, error de servidor), el sistema registra el error en un log y no actualiza el estado de la cita, intentándolo de nuevo en la próxima ejecución programada.

## 6. ARQUITECTURA DETALLADA

### 6.1 Stack Tecnológico

- **Frontend**: React.js con componentes funcionales, Tailwind CSS para el diseño.
- **Backend (API Principal)**: ASP.NET Core Web API (CRUD de pacientes, citas y notas).
- **Backend (Microservicio Autenticación)**: Spring Boot para Autenticación y Usuarios, con Spring Security y JWT.
- **Backend (Microservicio Notificaciones)**: Spring Boot para la lógica de notificaciones programadas.

### 6.2 Diseño de Base de Datos

Se mantiene el diseño de las tablas `Patients`, `Appointments` y `SessionNotes`. La tabla `Users` será manejada exclusivamente por el microservicio de Spring Boot.

### 6.3 Flujo de Comunicación (Microservicios)

1. **Login**: El frontend llama al endpoint `/auth/login` del microservicio de Autenticación. Este valida las credenciales y devuelve un token JWT.
2. **Llamadas Protegidas**: Para acceder a cualquier recurso en la API principal o en el microservicio de Notificaciones, el frontend debe incluir el token JWT en la cabecera `Authorization: Bearer <token>`.
3. **Validación del Token**: La API principal y el microservicio de Notificaciones tienen un middleware que intercepta cada solicitud, valida el token JWT y extrae la identidad del usuario para autorizar la solicitud.
4. **Flujo Asíncrono**: Cuando se crea una cita, la API principal registra el evento y el microservicio de Notificaciones, que accede a la base de datos, lo detecta y envía el email de confirmación y programa los recordatorios de manera asíncrona.

## 7. CONSIDERACIONES ADICIONALES

- **Escalabilidad**: Al separar la autenticación y las notificaciones en microservicios, el sistema puede manejar un aumento de usuarios y recordatorios sin afectar el rendimiento de los otros módulos.
- **Mantenimiento**: Cada módulo tiene una responsabilidad clara, facilitando la depuración y el mantenimiento.
- **Seguridad**: Se centraliza la lógica de seguridad y de negocio sensible en servicios dedicados, garantizando una implementación consistente y robusta.