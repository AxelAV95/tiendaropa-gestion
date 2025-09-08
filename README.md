# Sistema de Gestión para Consultorio Psicológico Individual

Este es un sistema de gestión web simplificado, diseñado para ayudar a psicólogos independientes a digitalizar su práctica privada. El objetivo principal es reemplazar la agenda física y los registros en papel con una plataforma segura, intuitiva y centrada en las funcionalidades más esenciales: la gestión de pacientes, citas y notas de sesión.

El proyecto está construido con un enfoque de arquitectura limpia y escalable, utilizando tecnologías modernas para el backend y el frontend.

-----

### Características Principales

  * **Gestión de Pacientes**: Un módulo completo para registrar, editar y buscar información básica de pacientes.
  * **Agenda y Calendario Interactivo**: Visualiza y administra citas en una vista semanal o mensual. Permite crear, editar, reprogramar y cancelar citas fácilmente.
  * **Notas de Sesión Seguras**: Registra observaciones detalladas después de cada cita, creando un historial cronológico y confidencial para cada paciente.
  * **Notificaciones Automáticas**: Envía recordatorios de citas por correo electrónico para reducir las ausencias.
  * **Reportes Básicos**: Genera informes simples para visualizar la actividad del consultorio, como el total de citas por mes o el número de pacientes activos.
  * **Seguridad y Usabilidad**: Incluye un login seguro, conexión HTTPS obligatoria y un diseño responsive para usarlo desde cualquier dispositivo.

-----

### Arquitectura y Tecnologías

Este sistema sigue un modelo de arquitectura de software de **microservicios**, dividida en las siguientes capas:

#### Backend

El backend se compone de dos microservicios principales:

1.  **Microservicio de Autenticación (`Authentication Service`)**: Un servicio dedicado a la gestión de usuarios y la autenticación.

      * **Tecnología**: Desarrollado con **Spring Boot** y Java.
      * **Funcionalidades**: Maneja el registro de usuarios, login, recuperación y cambio de contraseña.

2.  **Microservicio de Lógica de Negocio (`Core Business Service`)**: La API principal que maneja los datos de la clínica.

      * **Tecnología**: Construido con **ASP.NET Core 8 Web API** y C\#.
      * **Funcionalidades**: Gestiona la información de pacientes, citas y notas de sesión.

#### Frontend

Una interfaz de usuario moderna y dinámica desarrollada con:

  * **React.js**: Para construir la interfaz de usuario con componentes funcionales.
  * **Axios**: Para la comunicación con las APIs del backend.
  * **React Router**: Para gestionar la navegación entre las diferentes vistas de la aplicación.
  * **Tailwind CSS**: Para un diseño responsivo y consistente.

-----

### Estructura del Repositorio

```
/psicologo-consultorio
├── /src
│   ├── /Backend
│   │   ├── /AuthenticationService (Microservicio de Spring Boot)
│   │   │   └── ...
│   │   └── /CoreBusinessService (Microservicio de .NET Core)
│   │       └── ...
│   └── /Frontend
│       ├── /src
│       │   ├── /components
│       │   ├── /pages
│       │   ├── /services (API calls)
│       │   └── App.js
└── README.md
```

-----

### Cómo Empezar

#### Requisitos Previos

  * .NET SDK 8 o superior
  * JDK 17 o superior
  * Node.js y npm
  * SQL Server LocalDB o SQL Express

#### Configuración

1.  **Clona el repositorio:**

    ```bash
    git clone https://github.com/tu-usuario/psicologo-consultorio.git
    cd psicologo-consultorio
    ```

2.  **Configura los microservicios del backend:**

      * **Para el `CoreBusinessService` (en C\#):**
        ```bash
        cd src/Backend/CoreBusinessService
        dotnet restore
        # Actualiza la cadena de conexión en appsettings.json
        dotnet ef database update
        dotnet run
        ```
      * **Para el `AuthenticationService` (en Java):**
        ```bash
        cd src/Backend/AuthenticationService
        # Configura la base de datos en application.properties
        # Compila y ejecuta la aplicación (p. ej., con Maven o Gradle)
        ./mvnw spring-boot:run
        ```

3.  **Configura el frontend:**

    ```bash
    cd src/Frontend

    # Instala las dependencias
    npm install

    # Inicia la aplicación en modo de desarrollo
    npm start
    ```

4.  **Accede al sistema**:
    El frontend se abrirá en tu navegador en `http://localhost:3000` y se conectará con los dos microservicios del backend.

-----

