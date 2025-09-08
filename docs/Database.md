## Esquema Lógico de Base de Datos para Consultorio Psicológico



El sistema principal se basa en una arquitectura de microservicios. El **Microservicio de Autenticación** (construido con Spring Boot) gestionará la tabla `Users` en su propia base de datos, mientras que el **Microservicio de Lógica de Negocio** (ASP.NET Core) manejará las tablas `Patients`, `Appointments` y `SessionNotes` en una base de datos separada.

------



## 1. Microservicio de Autenticación (Spring Boot)



Este microservicio gestionará únicamente la información de los usuarios que acceden al sistema. Tendrá su propia base de datos.



### Tabla: `Users`



| Columna        | Tipo de Dato   | Restricciones                        | Descripción                                        |
| -------------- | -------------- | ------------------------------------ | -------------------------------------------------- |
| `Id`           | `BIGINT`       | `PRIMARY KEY`, `AUTO_INCREMENT`      | Identificador único del usuario.                   |
| `Email`        | `VARCHAR(255)` | `UNIQUE`, `NOT NULL`                 | Correo electrónico del usuario (para login).       |
| `PasswordHash` | `VARCHAR(255)` | `NOT NULL`                           | Hash seguro de la contraseña.                      |
| `FirstName`    | `VARCHAR(100)` | `NOT NULL`                           | Nombre del usuario.                                |
| `LastName`     | `VARCHAR(100)` | `NOT NULL`                           | Apellido del usuario.                              |
| `Phone`        | `VARCHAR(20)`  | `NULLABLE`                           | Número de teléfono de contacto.                    |
| `Role`         | `VARCHAR(50)`  | `NOT NULL`, `DEFAULT 'Psychologist'` | Rol del usuario en el sistema.                     |
| `IsActive`     | `BOOLEAN`      | `NOT NULL`, `DEFAULT TRUE`           | Indica si la cuenta del usuario está activa.       |
| `CreatedAt`    | `DATETIME`     | `NOT NULL`                           | Fecha y hora de creación del registro.             |
| `UpdatedAt`    | `DATETIME`     | `NOT NULL`                           | Última fecha y hora de actualización del registro. |

------



## 2. Microservicio de Lógica de Negocio (ASP.NET Core)



Este microservicio gestionará la información central del consultorio: pacientes, citas y notas de sesión. En este microservicio, las referencias al `UserId` se harán utilizando el ID proporcionado por el Microservicio de Autenticación, pero no se mantendrá una clave foránea física directamente, sino una referencia lógica.



### Tabla: `Patients`



| Columna            | Tipo de Dato    | Restricciones                  | Descripción                                         |
| ------------------ | --------------- | ------------------------------ | --------------------------------------------------- |
| `Id`               | `INT`           | `PRIMARY KEY`, `IDENTITY(1,1)` | Identificador único del paciente.                   |
| `FirstName`        | `NVARCHAR(100)` | `NOT NULL`                     | Nombre del paciente.                                |
| `LastName`         | `NVARCHAR(100)` | `NOT NULL`                     | Apellido del paciente.                              |
| `Phone`            | `NVARCHAR(20)`  | `NOT NULL`, `INDEXED`          | Número de teléfono principal del paciente.          |
| `Email`            | `NVARCHAR(255)` | `NULLABLE`                     | Correo electrónico del paciente.                    |
| `BirthDate`        | `DATE`          | `NULLABLE`                     | Fecha de nacimiento del paciente.                   |
| `IsActive`         | `BIT`           | `NOT NULL`, `DEFAULT 1`        | Indica si el paciente está activo en la clínica.    |
| `EmergencyContact` | `NVARCHAR(200)` | `NULLABLE`                     | Nombre del contacto de emergencia.                  |
| `EmergencyPhone`   | `NVARCHAR(20)`  | `NULLABLE`                     | Número de teléfono del contacto de emergencia.      |
| `CreatedAt`        | `DATETIME`      | `NOT NULL`                     | Fecha y hora de creación del registro del paciente. |
| `UpdatedAt`        | `DATETIME`      | `NOT NULL`                     | Última fecha y hora de actualización del registro.  |



### Tabla: `Appointments`



| Columna              | Tipo de Dato    | Restricciones                           | Descripción                                                  |
| -------------------- | --------------- | --------------------------------------- | ------------------------------------------------------------ |
| `Id`                 | `INT`           | `PRIMARY KEY`, `IDENTITY(1,1)`          | Identificador único de la cita.                              |
| `PatientId`          | `INT`           | `NOT NULL`, `FOREIGN KEY (Patients.Id)` | Identificador del paciente asociado a la cita.               |
| `PsychologistUserId` | `BIGINT`        | `NOT NULL`                              | **Referencia lógica al `Id` del `Users` del Microservicio de Autenticación**. Identifica al psicólogo que atiende la cita. |
| `AppointmentDate`    | `DATE`          | `NOT NULL`                              | Fecha de la cita.                                            |
| `StartTime`          | `TIME`          | `NOT NULL`                              | Hora de inicio de la cita.                                   |
| `Duration`           | `INT`           | `NOT NULL`, `DEFAULT 45`                | Duración de la cita en minutos.                              |
| `Status`             | `NVARCHAR(50)`  | `NOT NULL`, `DEFAULT 'Scheduled'`       | Estado actual de la cita (ej. 'Scheduled', 'Completed', 'Canceled'). |
| `Notes`              | `NVARCHAR(MAX)` | `NULLABLE`                              | Notas internas sobre la cita.                                |
| `CancellationReason` | `NVARCHAR(MAX)` | `NULLABLE`                              | Razón por la cual la cita fue cancelada.                     |
| `CreatedAt`          | `DATETIME`      | `NOT NULL`                              | Fecha y hora de creación del registro de la cita.            |
| `UpdatedAt`          | `DATETIME`      | `NOT NULL`                              | Última fecha y hora de actualización del registro.           |



### Tabla: `SessionNotes`



| Columna         | Tipo de Dato    | Restricciones                                         | Descripción                                                  |
| --------------- | --------------- | ----------------------------------------------------- | ------------------------------------------------------------ |
| `Id`            | `INT`           | `PRIMARY KEY`, `IDENTITY(1,1)`                        | Identificador único de la nota de sesión.                    |
| `PatientId`     | `INT`           | `NOT NULL`, `FOREIGN KEY (Patients.Id)`               | Identificador del paciente al que pertenece la nota.         |
| `AppointmentId` | `INT`           | `NULLABLE`, `UNIQUE`, `FOREIGN KEY (Appointments.Id)` | Identificador de la cita asociada (opcional, si la nota se crea a partir de una cita). |
| `SessionDate`   | `DATETIME`      | `NOT NULL`                                            | Fecha y hora en que se realizó la sesión o se tomó la nota.  |
| `Content`       | `NVARCHAR(MAX)` | `NOT NULL`                                            | Contenido detallado de la nota de sesión.                    |
| `NextSteps`     | `NVARCHAR(MAX)` | `NULLABLE`                                            | Acciones o seguimiento a realizar.                           |
| `CreatedAt`     | `DATETIME`      | `NOT NULL`                                            | Fecha y hora de creación de la nota.                         |
| `UpdatedAt`     | `DATETIME`      | `NOT NULL`                                            | Última fecha y hora de actualización de la nota.             |

------



## Relaciones Entre Tablas



Dada la arquitectura de microservicios, las relaciones se gestionan de la siguiente manera:



### Relaciones dentro del Microservicio de Lógica de Negocio:



- **`Patients` (Uno) a `Appointments` (Muchos)**
  - Un paciente puede tener múltiples citas.
  - `Appointments.PatientId` es una clave foránea que referencia a `Patients.Id`.
- **`Patients` (Uno) a `SessionNotes` (Muchos)**
  - Un paciente puede tener múltiples notas de sesión.
  - `SessionNotes.PatientId` es una clave foránea que referencia a `Patients.Id`.
- **`Appointments` (Uno) a `SessionNotes` (Uno)**
  - Una cita puede tener una única nota de sesión asociada.
  - `SessionNotes.AppointmentId` es una clave foránea que referencia a `Appointments.Id`. Es `NULLABLE` para permitir notas de sesión que no estén directamente ligadas a una cita formal.



### Relación entre Microservicios:



- **`Users` (Microservicio de Autenticación) a `Appointments` (Microservicio de Lógica de Negocio)**
  - Un usuario (psicólogo) puede tener muchas citas.
  - La relación aquí es **lógica** a través del campo `Appointments.PsychologistUserId`. Este campo almacena el `Id` del usuario obtenido del Microservicio de Autenticación, pero no es una clave foránea física en la base de datos del Microservicio de Lógica de Negocio. La integridad referencial se gestionará a nivel de aplicación (mediante llamadas a la API del Microservicio de Autenticación para validar IDs de usuario).

------