# Sistema de Gestión para Tienda de Ropa Boutique
<p align="center"><img width="300" height="300" alt="boutique-system" src="https://images.unsplash.com/photo-1441986300917-64674bd600d8?w=400&h=400&fit=crop&crop=center" /></p>

Este es un sistema de gestión web simplificado, diseñado para ayudar a propietarios de tiendas de ropa independientes a digitalizar su negocio. El objetivo principal es reemplazar el control de inventario manual y los registros en papel con una plataforma segura, intuitiva y centrada en las funcionalidades más esenciales: la gestión de productos, inventario, ventas y clientes.

El proyecto está construido con un enfoque de arquitectura limpia y escalable, utilizando tecnologías modernas para el backend y el frontend.

-----

### Características Principales

  * **Gestión de Productos**: Un módulo completo para registrar, editar y buscar productos con sus variantes (tallas, colores, estilos).
  * **Control de Inventario Inteligente**: Visualiza y administra el stock en tiempo real. Recibe alertas automáticas cuando los productos estén por agotarse.
  * **Sistema de Ventas Completo**: Procesa ventas con múltiples productos, calcula totales automáticamente y genera comprobantes digitales.
  * **Gestión de Clientes**: Mantén un registro de clientes habituales con su historial de compras y programa de fidelidad basado en puntos.
  * **Reportes y Analíticas**: Genera informes detallados de ventas, productos más vendidos y tendencias para tomar mejores decisiones comerciales.
  * **Notificaciones Automáticas**: Recibe alertas por email sobre stock bajo, resúmenes de ventas diarias y eventos importantes.
  * **Seguridad y Usabilidad**: Incluye un login seguro, conexión HTTPS obligatoria y un diseño responsive para usarlo desde cualquier dispositivo.

-----

### Arquitectura y Tecnologías

Este sistema sigue un modelo de arquitectura de software de **microservicios**, dividida en las siguientes capas:

#### Backend

El backend se compone de dos microservicios principales:

1.  **Microservicio de Autenticación (`Authentication Service`)**: Un servicio dedicado a la gestión de usuarios y la autenticación.

      * **Tecnología**: Desarrollado con **Spring Boot** y Java.
      * **Funcionalidades**: Maneja el registro de usuarios, login, recuperación y cambio de contraseña, gestión de roles (Gerente/Vendedor).

2.  **Microservicio de Lógica de Negocio (`Core Business Service`)**: La API principal que maneja los datos de la tienda.

      * **Tecnología**: Construido con **ASP.NET Core 8 Web API** y C#.
      * **Funcionalidades**: Gestiona la información de productos, inventario, ventas, clientes y reportes.

3.  **Microservicio de Notificaciones (`Notification Service`)**: Servicio dedicado al envío de alertas y notificaciones.

      * **Tecnología**: Desarrollado con **Spring Boot** y Java.
      * **Funcionalidades**: Envío automático de emails para alertas de stock bajo y resúmenes diarios de ventas.

#### Frontend

Una interfaz de usuario moderna y dinámica desarrollada con:

  * **React.js**: Para construir la interfaz de usuario con componentes funcionales y hooks.
  * **Axios**: Para la comunicación con las APIs del backend.
  * **React Router**: Para gestionar la navegación entre las diferentes vistas de la aplicación.
  * **Tailwind CSS**: Para un diseño responsivo, moderno y consistente.
  * **Recharts**: Para visualizaciones de datos y gráficos en los reportes.

-----

### Funcionalidades por Módulo

#### 🏷️ Gestión de Productos
- Registro de productos con código único, categorías y precios
- Manejo de variantes (tallas, colores) con stock independiente
- Búsqueda avanzada por código, nombre o categoría
- Estados de productos (activo, descontinuado)

#### 📦 Control de Inventario
- Actualización automática de stock con cada venta
- Alertas inteligentes de stock bajo personalizable por producto
- Registro de entradas de mercancía con trazabilidad completa
- Historial detallado de todos los movimientos de inventario

#### 💰 Sistema de Ventas
- Interfaz intuitiva tipo punto de venta (POS)
- Soporte para múltiples métodos de pago
- Cálculo automático de impuestos y descuentos
- Generación de comprobantes digitales
- Registro de ventas anónimas o asociadas a clientes

#### 👥 Gestión de Clientes
- Base de datos de clientes con información de contacto
- Historial completo de compras por cliente
- Sistema de puntos de fidelidad automático
- Seguimiento del valor total de vida del cliente (CLV)

#### 📊 Reportes y Analíticas
- Dashboard con métricas clave de ventas
- Reportes de productos más y menos vendidos
- Análisis de tendencias de ventas por período
- Reportes de inventario y rotación de stock
- Exportación a PDF para todos los reportes

-----

### Estructura del Repositorio

```
/boutique-management-system
├── /src
│   ├── /Backend
│   │   ├── /AuthenticationService (Microservicio de Spring Boot)
│   │   │   ├── /src/main/java/com/boutique/auth
│   │   │   ├── /src/main/resources
│   │   │   └── pom.xml
│   │   ├── /CoreBusinessService (Microservicio de .NET Core)
│   │   │   ├── /Controllers
│   │   │   ├── /Models
│   │   │   ├── /Services
│   │   │   ├── /Data
│   │   │   └── Program.cs
│   │   └── /NotificationService (Microservicio de Spring Boot)
│   │       ├── /src/main/java/com/boutique/notifications
│   │       └── pom.xml
│   └── /Frontend
│       ├── /src
│       │   ├── /components
│       │   │   ├── /products
│       │   │   ├── /inventory
│       │   │   ├── /sales
│       │   │   ├── /customers
│       │   │   └── /reports
│       │   ├── /pages
│       │   ├── /services (API calls)
│       │   ├── /utils
│       │   └── App.js
│       ├── package.json
│       └── tailwind.config.js
├── /docs
│   ├── database-schema.md
│   ├── api-documentation.md
│   └── user-manual.md
└── README.md
```

-----

### Cómo Empezar

#### Requisitos Previos

  * .NET SDK 8 o superior
  * JDK 17 o superior (para Spring Boot)
  * Node.js 18+ y npm
  * SQL Server LocalDB, SQL Express o PostgreSQL
  * Maven 3.6+ (para los microservicios de Spring Boot)

#### Configuración Rápida

1.  **Clona el repositorio:**

    ```bash
    git clone https://github.com/AxelAV95/tiendaropa-gestion.git
    cd tiendaropa-gestion
    ```

2.  **Configura los microservicios del backend:**

      * **Para el `CoreBusinessService` (ASP.NET Core):**
        ```bash
        cd src/Backend/CoreBusinessService
        dotnet restore
        
        # Actualiza la cadena de conexión en appsettings.json
        # Ejemplo: "Server=localhost;Database=BoutiqueCore;Trusted_Connection=true;"
        
        # Ejecuta las migraciones de base de datos
        dotnet ef database update
        
        # Inicia el servicio (puerto 5001 por defecto)
        dotnet run
        ```

      * **Para el `AuthenticationService` (Spring Boot):**
        ```bash
        cd src/Backend/AuthenticationService
        
        # Configura la base de datos en src/main/resources/application.properties
        # spring.datasource.url=jdbc:sqlserver://localhost:1433;databaseName=BoutiqueAuth
        
        # Compila y ejecuta la aplicación
        ./mvnw clean install
        ./mvnw spring-boot:run
        ```

      * **Para el `NotificationService` (Spring Boot):**
        ```bash
        cd src/Backend/NotificationService
        
        # Configura el servidor SMTP en application.properties
        # spring.mail.host=smtp.gmail.com
        # spring.mail.username=tu-email@gmail.com
        
        ./mvnw clean install
        ./mvnw spring-boot:run
        ```

3.  **Configura el frontend:**

    ```bash
    cd src/Frontend

    # Instala las dependencias
    npm install

    # Configura las URLs de los microservicios en src/config/api.js
    # const API_BASE_URL = 'https://localhost:5001/api'
    # const AUTH_BASE_URL = 'http://localhost:8080/api/auth'

    # Inicia la aplicación en modo de desarrollo
    npm start
    ```

4.  **Accede al sistema**:
    
    * Frontend: `http://localhost:3000`
    * Core Business API: `https://localhost:5001/swagger` (documentación)
    * Authentication API: `http://localhost:8080/swagger-ui.html` (documentación)
    * Notification API: `http://localhost:8081/actuator/health` (health check)

#### Usuario por Defecto

Al ejecutar por primera vez, el sistema creará un usuario administrador:
- **Email**: `admin@boutique.com`
- **Contraseña**: `Admin123!`

-----

### Desarrollo

#### Scripts Disponibles

En el directorio del frontend:
- `npm start` - Inicia el servidor de desarrollo
- `npm build` - Construye la aplicación para producción
- `npm test` - Ejecuta las pruebas unitarias
- `npm run lint` - Ejecuta el linter de código

#### Configuración de Base de Datos

El sistema soporta tanto SQL Server como PostgreSQL. Configura la cadena de conexión apropiada en:
- **ASP.NET Core**: `appsettings.json`
- **Spring Boot**: `application.properties`

#### Variables de Entorno

Crea archivos `.env` para configuración local:

**Frontend (.env):**
```
REACT_APP_API_URL=https://localhost:5001/api
REACT_APP_AUTH_URL=http://localhost:8080/api/auth
REACT_APP_NOTIFICATION_URL=http://localhost:8081/api/notifications
```

**Spring Boot (application-local.properties):**
```
spring.profiles.active=local
spring.datasource.url=jdbc:sqlserver://localhost:1433;databaseName=BoutiqueAuth
spring.mail.host=smtp.gmail.com
spring.mail.username=${MAIL_USERNAME}
spring.mail.password=${MAIL_PASSWORD}
```

-----

### Despliegue

#### Para Desarrollo
1. Ejecuta cada microservicio en su puerto correspondiente
2. Inicia el frontend con `npm start`
3. Accede a `http://localhost:3000`

#### Para Producción
1. Construye el frontend: `npm run build`
2. Despliega los microservicios en contenedores Docker
3. Configura un reverse proxy (Nginx) para rutear las peticiones
4. Configura HTTPS con certificados SSL

-----

### Contribuir

1. Fork el repositorio
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request
