# Sistema de Gestión para Tienda de Ropa Boutique

## 1. ANÁLISIS SIMPLIFICADO

### 1.1 Descripción del Sistema

Sistema web sencillo para una tienda de ropa independiente que busca digitalizar la gestión de su boutique, enfocándose en lo esencial: inventario, ventas, clientes y reportes básicos.

### 1.2 Objetivos Principales

- Reemplazar el control de inventario manual por un sistema digital.
- Centralizar la información de productos y stock.
- Llevar un registro seguro de ventas y transacciones.
- Automatizar alertas de stock bajo.
- Generar reportes simples de ventas y productos más vendidos.

### 1.3 Usuarios

- **Propietario/Gerente**: Usuario principal y único administrador.
- **Vendedor** (opcional): Con permisos limitados para registrar ventas y consultar productos.

## 2. MÓDULOS DEL SISTEMA

### 2.1 Microservicio de Autenticación y Gestión de Usuarios (Spring Boot)

Este es un componente independiente. Se encarga de la seguridad y los usuarios.

- Funcionalidades

  :

  - Registro de usuarios.
  - Autenticación con email/contraseña.
  - Recuperación y cambio de contraseña.
  - Gestión de roles de usuario (Gerente, Vendedor).
  - Revocación de tokens de acceso.

- **Tecnologías**: Spring Boot, Spring Security, JWT (JSON Web Tokens), Base de Datos.

### 2.2 Módulo de Gestión de Productos

Permite el manejo del catálogo de productos de la tienda.

- Funcionalidades

  :

  - Registro, edición y búsqueda de productos.
  - Control de stock y variantes (tallas, colores).
  - Estados: disponible/agotado/descontinuado.
  - Categorías y subcategorías de productos.

### 2.3 Módulo de Gestión de Inventario

Ofrece control total sobre el stock y movimientos de productos.

- Funcionalidades

  :

  - Actualización de stock en tiempo real.
  - Alertas automáticas de stock bajo.
  - Historial de movimientos de inventario.
  - Registro de entradas de mercancía.

### 2.4 Módulo de Ventas y Facturación

Permite registrar las ventas y generar comprobantes.

- Funcionalidades

  :

  - Registrar ventas con múltiples productos.
  - Calcular totales, descuentos e impuestos.
  - Generar tickets de venta.
  - Control de métodos de pago (efectivo, tarjeta, transferencia).

### 2.5 Módulo de Gestión de Clientes

Maneja la información básica de los clientes habituales.

- Funcionalidades

  :

  - Registro de clientes con datos básicos.
  - Historial de compras por cliente.
  - Sistema simple de puntos o descuentos por fidelidad.

### 2.6 Módulo de Reportes

Genera reportes de actividad para la tienda.

- Funcionalidades

  :

  - Reportes de ventas diarias, semanales y mensuales.
  - Productos más vendidos y de menor rotación.
  - Exportación de reportes a PDF.

### 2.7 Módulo de Notificaciones Automáticas

Microservicio encargado de enviar alertas automáticas.

- Funcionalidades

  :

  - Envío de alertas de stock bajo.
  - Notificaciones de ventas importantes.
  - Recordatorios de tareas pendientes.

- **Tecnologías**: Spring Boot, Spring Scheduling, JavaMailSender, Base de Datos.

## 3. REQUERIMIENTOS FUNCIONALES DETALLADOS

### 3.1 Módulo de Autenticación y Usuarios (Microservicio)

- **RF-01**: Como usuario, quiero registrarme con email y contraseña.
- **RF-02**: Como usuario, quiero iniciar sesión con mis credenciales.
- **RF-03**: Como usuario, quiero solicitar un enlace para restablecer mi contraseña por email.
- **RF-04**: Como usuario, quiero cambiar mi contraseña actual.
- **RF-05**: El sistema debe manejar dos roles: "Gerente" (rol por defecto) y "Vendedor".
- **RF-06**: El sistema debe generar un token JWT tras el inicio de sesión para la autenticación en otros módulos.
- **RF-07**: El sistema debe revocar los tokens de acceso al cerrar sesión.

### 3.2 Módulo de Gestión de Productos

- **RF-08**: Registrar un producto con campos obligatorios: nombre, código, precio, categoría y stock inicial.
- **RF-09**: El sistema debe validar que no existan productos duplicados por código.
- **RF-10**: El sistema debe permitir editar la información de un producto.
- **RF-11**: El sistema debe permitir buscar productos por nombre, código o categoría.
- **RF-12**: El sistema debe mostrar una lista de todos los productos, con opción de filtro por estado y categoría.
- **RF-13**: El sistema debe permitir gestionar variantes de productos (tallas, colores) con stock independiente.

### 3.3 Módulo de Gestión de Inventario

- **RF-14**: El sistema debe actualizar automáticamente el stock cuando se registre una venta.
- **RF-15**: El sistema debe generar alertas cuando el stock de un producto esté por debajo del mínimo establecido.
- **RF-16**: El sistema debe permitir registrar entradas de mercancía al inventario.
- **RF-17**: El sistema debe mantener un historial de todos los movimientos de inventario.
- **RF-18**: El sistema debe mostrar el valor total del inventario actual.

### 3.4 Módulo de Ventas y Facturación

- **RF-19**: El sistema debe permitir crear una venta seleccionando productos y cantidades.
- **RF-20**: El sistema debe validar que haya stock suficiente antes de confirmar la venta.
- **RF-21**: El sistema debe calcular automáticamente subtotales, descuentos e impuestos.
- **RF-22**: El sistema debe permitir seleccionar el método de pago.
- **RF-23**: El sistema debe generar un comprobante de venta en formato digital.
- **RF-24**: El sistema debe permitir aplicar descuentos por producto o por venta total.

### 3.5 Módulo de Gestión de Clientes

- **RF-25**: El sistema debe permitir registrar clientes con datos básicos: nombre, teléfono y email.
- **RF-26**: El sistema debe mostrar el historial de compras de cada cliente.
- **RF-27**: El sistema debe calcular puntos de fidelidad basados en el monto de compras.
- **RF-28**: El sistema debe permitir buscar clientes por nombre o teléfono.

### 3.6 Módulo de Reportes

- **RF-29**: El sistema debe generar reportes de ventas por período (día, semana, mes).
- **RF-30**: El sistema debe generar un reporte de productos más vendidos.
- **RF-31**: El sistema debe generar un reporte de productos con bajo stock.
- **RF-32**: El sistema debe exportar los reportes a formato PDF.
- **RF-33**: El sistema debe mostrar gráficos simples de ventas y tendencias.

### 3.7 Módulo de Notificaciones

- **RF-34**: El sistema debe enviar una notificación por email cuando el stock de un producto esté bajo.
- **RF-35**: El sistema debe enviar un resumen diario de ventas por email al gerente.
- **RF-36**: El sistema debe registrar en la base de datos el estado de envío de cada notificación.

## 4. REQUERIMIENTOS NO FUNCIONALES

- **RNF-01**: **Seguridad**: El login debe ser seguro, las contraseñas cifradas y los datos de ventas deben estar protegidos por HTTPS.
- **RNF-02**: **Usabilidad**: La interfaz debe ser intuitiva y el sistema debe ser "responsive" para usarse en tablets y dispositivos móviles.
- **RNF-03**: **Rendimiento**: La carga de las pantallas principales debe ser menor a 3 segundos.
- **RNF-04**: **Disponibilidad**: El sistema debe tener un tiempo de actividad del 99%.
- **RNF-05**: **Arquitectura**: Los módulos de autenticación y notificaciones deben ser microservicios independientes, que los otros módulos consuman a través de una API REST.

## 5. CASOS DE USO COMPLETOS

### 5.1 CU-001: Registro de Usuario (Microservicio de Autenticación)

- **Actor**: Gerente.

- **Precondiciones**: El usuario no existe en la base de datos.

- Flujo Principal

  :

  1. El usuario accede a la página de registro.
  2. El sistema muestra un formulario con campos para nombre, email y contraseña.
  3. El usuario ingresa sus datos y hace clic en "Registrarse".
  4. El frontend envía la solicitud al microservicio de autenticación.
  5. El microservicio valida los datos, cifra la contraseña y la guarda en la base de datos.
  6. Si es exitoso, devuelve una respuesta con el nuevo usuario registrado.

- Flujos Alternativos

  :

  - **A1 - Email ya registrado**: El microservicio devuelve un error indicando que el email ya está en uso.

- **Postcondiciones**: Un nuevo usuario es creado con el rol "Gerente" y puede iniciar sesión.

### 5.2 CU-002: Registrar Producto Nuevo

- **Actor**: Gerente.

- **Precondiciones**: El gerente está autenticado.

- Flujo Principal

  :

  1. El gerente accede al módulo de productos.
  2. Hace clic en "Nuevo Producto". El sistema muestra un formulario.
  3. El gerente completa los datos obligatorios del producto.
  4. El frontend envía la solicitud de registro al backend con el token JWT.
  5. El backend valida el token y los permisos.
  6. El backend valida que no exista un producto con el mismo código.
  7. Si las validaciones son correctas, el backend guarda el nuevo producto.
  8. El sistema redirige al gerente a la lista de productos, mostrando el nuevo registro.

- Flujos Alternativos

  :

  - **A1 - Código duplicado**: El backend devuelve un error de conflicto.

- **Postcondiciones**: El producto queda registrado y disponible para ventas.

### 5.3 CU-003: Procesar Venta

- **Actor**: Vendedor o Gerente.

- **Precondiciones**: El usuario está autenticado y hay productos en stock.

- Flujo Principal

  :

  1. El vendedor accede al módulo de ventas.
  2. Hace clic en "Nueva Venta". El sistema muestra la interfaz de venta.
  3. El vendedor busca y agrega productos al carrito, especificando cantidades.
  4. El sistema valida que hay stock suficiente para cada producto.
  5. El vendedor selecciona el cliente (si es conocido) y el método de pago.
  6. El sistema calcula el total con impuestos y descuentos aplicables.
  7. El vendedor confirma la venta.
  8. El backend registra la venta, actualiza el stock y genera el comprobante.
  9. El sistema actualiza automáticamente el inventario.

- Flujos Alternativos

  :

  - **A1 - Stock insuficiente**: El sistema muestra una advertencia y ajusta la cantidad disponible.

- **Postcondiciones**: La venta queda registrada, el stock actualizado y se genera el comprobante.

### 5.4 CU-004: Actualizar Inventario por Llegada de Mercancía

- **Actor**: Gerente.

- **Precondiciones**: El gerente está autenticado y hay productos registrados.

- Flujo Principal

  :

  1. El gerente accede al módulo de inventario.
  2. Selecciona "Entrada de Mercancía".
  3. Busca y selecciona los productos que llegaron.
  4. Ingresa las cantidades recibidas para cada producto.
  5. Opcionalmente agrega notas sobre la entrada (proveedor, fecha de llegada).
  6. El sistema actualiza el stock de cada producto.
  7. El sistema registra el movimiento en el historial de inventario.

- **Postcondiciones**: El stock se actualiza y queda registrado el movimiento.

### 5.5 CU-005: Generar Reporte de Ventas Mensual

- **Actor**: Gerente.

- **Precondiciones**: El gerente está autenticado y hay ventas registradas.

- Flujo Principal

  :

  1. El gerente accede al módulo de reportes.
  2. Selecciona "Reporte de Ventas" y elige el mes y año deseados.
  3. El frontend envía la solicitud de reporte al backend.
  4. El backend consulta la información de ventas para ese período.
  5. El backend procesa los datos y calcula métricas (total vendido, productos más vendidos, etc.).
  6. El sistema renderiza el reporte con gráficos y tablas.
  7. El gerente puede exportar el reporte a PDF.

- Flujos Alternativos

  :

  - **A1 - Sin datos**: El sistema muestra "No hay ventas para el período seleccionado".

### 5.6 CU-006: Envío de Alerta de Stock Bajo (Microservicio de Notificaciones)

- **Actor**: Sistema (proceso automatizado).

- **Precondiciones**: Existe al menos un producto con stock por debajo del mínimo.

- Flujo Principal

  :

  1. El microservicio de notificaciones ejecuta una tarea programada diariamente.
  2. El microservicio consulta la base de datos para encontrar productos con stock bajo.
  3. Por cada producto encontrado, el microservicio recupera la información del gerente.
  4. El microservicio compone y envía un correo de alerta con la lista de productos.
  5. El sistema registra que la notificación ha sido enviada.

- **Postcondiciones**: El gerente recibe una alerta por email sobre productos con stock bajo.

## 6. ARQUITECTURA DETALLADA

### 6.1 Stack Tecnológico

- **Frontend**: React.js con componentes funcionales, Tailwind CSS para el diseño.
- **Backend (API Principal)**: ASP.NET Core Web API (CRUD de productos, ventas, inventario y clientes).
- **Backend (Microservicio Autenticación)**: Spring Boot para Autenticación y Usuarios, con Spring Security y JWT.
- **Backend (Microservicio Notificaciones)**: Spring Boot para la lógica de notificaciones programadas.

### 6.2 Diseño de Base de Datos

#### Tablas principales:

- **Users**: Gestionada por el microservicio de Spring Boot
- **Products**: id, code, name, description, price, category, min_stock, status
- **ProductVariants**: id, product_id, size, color, stock_quantity
- **Sales**: id, customer_id, total_amount, tax_amount, payment_method, sale_date, user_id
- **SaleItems**: id, sale_id, product_variant_id, quantity, unit_price, subtotal
- **Customers**: id, name, phone, email, loyalty_points, registration_date
- **InventoryMovements**: id, product_variant_id, movement_type, quantity, notes, movement_date, user_id

### 6.3 Flujo de Comunicación (Microservicios)

1. **Login**: El frontend llama al endpoint `/auth/login` del microservicio de Autenticación.
2. **Llamadas Protegidas**: Para acceder a cualquier recurso, el frontend incluye el token JWT en la cabecera `Authorization: Bearer <token>`.
3. **Validación del Token**: La API principal y el microservicio de Notificaciones validan el token JWT.
4. **Flujo Asíncrono**: Cuando se procesa una venta, el sistema actualiza el inventario y el microservicio de Notificaciones detecta automáticamente si algún producto queda con stock bajo.

## 7. CONSIDERACIONES ADICIONALES

- **Escalabilidad**: La separación en microservicios permite manejar más usuarios y transacciones sin afectar el rendimiento.
- **Mantenimiento**: Cada módulo tiene responsabilidades claras, facilitando la depuración y mantenimiento.
- **Seguridad**: Se centraliza la lógica de seguridad en el microservicio de autenticación.
- **Flexibilidad**: El sistema puede expandirse fácilmente para agregar funcionalidades como ventas online, múltiples sucursales, etc.

## 8. CRONOGRAMA DE DESARROLLO SUGERIDO

### Fase 1 (2-3 semanas): Fundación

- Microservicio de Autenticación
- Módulo básico de Productos
- Interfaz de usuario básica

### Fase 2 (2 semanas): Core Business

- Módulo de Inventario
- Módulo de Ventas básico

### Fase 3 (1-2 semanas): Gestión

- Módulo de Clientes
- Reportes básicos

### Fase 4 (1 semana): Automatización

- Microservicio de Notificaciones
- Refinamiento y testing

Este cronograma está diseñado para ser completado en **6-8 semanas** trabajando medio tiempo, perfecto para practicar conceptos de desarrollo full-stack sin la complejidad de sistemas empresariales grandes.
