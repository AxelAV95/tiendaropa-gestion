# Guía Completa de Versionado de Software

## 📋 Índice

1. [Introducción](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#introducción)
2. [Versionado Semántico (SemVer)](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#versionado-semántico-semver)
3. [Tipos de Versiones](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#tipos-de-versiones)
4. [Nomenclatura y Formato](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#nomenclatura-y-formato)
5. [Cuándo Incrementar Cada Número](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#cuándo-incrementar-cada-número)
6. [Pre-releases y Metadatos](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#pre-releases-y-metadatos)
7. [Tags y Releases en Git](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#tags-y-releases-en-git)
8. [Changelog y Documentación](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#changelog-y-documentación)
9. [Herramientas Automatizadas](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#herramientas-automatizadas)
10. [Ejemplos Prácticos](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#ejemplos-prácticos)
11. [Mejores Prácticas](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#mejores-prácticas)
12. [Checklist](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#checklist)

## Introducción

El versionado es un sistema para numerar las diferentes versiones de tu software de manera consistente y comprensible. Una buena estrategia de versionado ayuda a:

### ¿Por qué es importante versionar?

- **Comunicación clara**: Los usuarios saben qué esperar de cada versión
- **Gestión de dependencias**: Otros proyectos pueden especificar qué versión usar
- **Rollback seguro**: Facilita volver a versiones anteriores si hay problemas
- **Planificación**: Ayuda a organizar releases y roadmaps
- **Soporte**: Permite dar soporte específico a versiones concretas

### Beneficios del Versionado Consistente

- Reduce confusión entre desarrolladores y usuarios
- Facilita la integración continua y despliegues
- Mejora la confianza en actualizaciones
- Simplifica el mantenimiento de múltiples versiones

## Versionado Semántico (SemVer)

El **Semantic Versioning** es el estándar más usado en la industria. Utiliza un formato de tres números separados por puntos:

### Formato Básico

```
MAJOR.MINOR.PATCH
```

### Ejemplo

```
2.1.4
│ │ │
│ │ └─ PATCH: Correcciones de errores
│ └─── MINOR: Nuevas funcionalidades (compatible)
└───── MAJOR: Cambios incompatibles
```

### Reglas Fundamentales

1. **MAJOR**: Se incrementa cuando hay cambios incompatibles en la API
2. **MINOR**: Se incrementa cuando se agrega funcionalidad compatible
3. **PATCH**: Se incrementa cuando se hacen correcciones compatibles

## Tipos de Versiones

### 🔧 **Versión de Desarrollo**

```
0.x.y
```

- **Propósito**: Software en desarrollo inicial
- **Estabilidad**: Inestable, cambios frecuentes
- **API**: Puede cambiar sin previo aviso
- **Ejemplo**: `0.1.0`, `0.5.3`, `0.12.7`

### 🚀 **Versión Estable**

```
1.0.0+
```

- **Propósito**: Primera versión lista para producción
- **Estabilidad**: API pública definida
- **Compatibilidad**: Se respetan las reglas SemVer
- **Ejemplo**: `1.0.0`, `2.3.1`, `5.12.8`

### 🧪 **Pre-release**

```
1.0.0-alpha.1
1.0.0-beta.2
1.0.0-rc.1
```

- **Propósito**: Versiones previas al lanzamiento
- **Testing**: Para pruebas específicas
- **Estabilidad**: Puede tener bugs conocidos

### 📦 **Versión LTS (Long Term Support)**

```
3.0.0-lts
```

- **Propósito**: Soporte extendido
- **Duración**: Soporte por años (ej: Node.js LTS)
- **Actualizaciones**: Solo security fixes y patches críticos

## Nomenclatura y Formato

### 📏 **Formato Completo de SemVer**

```
<major>.<minor>.<patch>-<pre-release>+<build-metadata>
```

### Componentes Detallados

#### **Major Version (X.0.0)**

```
1.0.0 → 2.0.0
```

**Cuándo incrementar:**

- Cambios incompatibles en la API
- Eliminación de funcionalidades
- Cambios en el comportamiento principal
- Migración de base de datos que rompe compatibilidad

#### **Minor Version (0.X.0)**

```
1.5.0 → 1.6.0
```

**Cuándo incrementar:**

- Nuevas funcionalidades compatibles
- Mejoras significativas
- Nuevos endpoints de API
- Funcionalidades marcadas como deprecated

#### **Patch Version (0.0.X)**

```
1.5.3 → 1.5.4
```

**Cuándo incrementar:**

- Corrección de bugs
- Security fixes
- Mejoras de rendimiento menores
- Correcciones de documentación

### 📝 **Reglas de Incremento**

1. **Major increment**: Resetea minor y patch a 0

   ```
   1.4.7 → 2.0.0
   ```

2. **Minor increment**: Resetea patch a 0

   ```
   1.4.7 → 1.5.0
   ```

3. **Patch increment**: Solo incrementa el último número

   ```
   1.4.7 → 1.4.8
   ```

## Cuándo Incrementar Cada Número

### 🔴 **Major Version (Breaking Changes)**

#### Cambios que requieren Major:

```javascript
// Versión 1.x.x
function getUserData(id) {
  return { id, name, email };
}

// Versión 2.0.0 - Breaking change
function getUserData(userId, options = {}) {
  return { 
    user: { userId, name, email },
    metadata: options
  };
}
```

#### Ejemplos de Major increments:

- Cambiar parámetros requeridos de funciones
- Eliminar endpoints de API
- Cambiar estructura de respuestas
- Actualizar a nueva versión mayor de framework
- Cambios en schema de base de datos

### 🟡 **Minor Version (New Features)**

#### Cambios que requieren Minor:

```javascript
// Versión 1.5.x
class UserService {
  getUser(id) { /* ... */ }
  updateUser(id, data) { /* ... */ }
}

// Versión 1.6.0 - Nueva funcionalidad
class UserService {
  getUser(id) { /* ... */ }
  updateUser(id, data) { /* ... */ }
  deleteUser(id) { /* ... */ }  // ✅ Nueva función
  getUserPreferences(id) { /* ... */ }  // ✅ Nueva función
}
```

#### Ejemplos de Minor increments:

- Agregar nuevos endpoints
- Nuevas funcionalidades opcionales
- Mejoras en la interfaz de usuario
- Nuevos parámetros opcionales
- Agregar nuevas validaciones

### 🟢 **Patch Version (Bug Fixes)**

#### Cambios que requieren Patch:

```javascript
// Versión 1.5.2 - Bug
function calculateTotal(items) {
  return items.reduce((sum, item) => sum + item.price, 0);
  // ❌ Bug: no maneja items undefined
}

// Versión 1.5.3 - Bug fix
function calculateTotal(items = []) {
  return items.reduce((sum, item) => sum + item.price, 0);
  // ✅ Fix: maneja items undefined
}
```

#### Ejemplos de Patch increments:

- Corrección de bugs
- Fixes de seguridad
- Correcciones de typos
- Optimizaciones menores
- Updates de documentación

## Pre-releases y Metadatos

### 🏷️ **Pre-release Identifiers**

#### **Alpha (α)**

```
1.0.0-alpha.1
1.0.0-alpha.2
```

- **Estado**: Desarrollo temprano
- **Estabilidad**: Muy inestable
- **Audiencia**: Solo desarrolladores internos
- **Funcionalidades**: Incompletas o experimentales

#### **Beta (β)**

```
1.0.0-beta.1
1.0.0-beta.2
```

- **Estado**: Funcionalidades completas
- **Estabilidad**: Relativamente estable
- **Audiencia**: Testers, early adopters
- **Propósito**: Encontrar bugs antes del release

#### **Release Candidate (RC)**

```
1.0.0-rc.1
1.0.0-rc.2
```

- **Estado**: Candidato a release final
- **Estabilidad**: Muy estable
- **Audiencia**: Usuarios finales para testing
- **Cambios**: Solo bug fixes críticos

### 🏗️ **Build Metadata**

```
1.0.0+20231201
1.0.0+build.1
1.0.0-beta.1+exp.sha.5114f85
```

- **Propósito**: Información de build
- **No afecta precedencia**: `1.0.0+build.1` = `1.0.0+build.2`
- **Ejemplos**: fecha, número de build, commit hash

### **Combinaciones Comunes**

```
1.0.0-alpha.1+build.123
1.0.0-beta.2+20231201.sha.abc123
1.0.0-rc.1+release.candidate
```

## Tags y Releases en Git

### 🏷️ **Crear Tags**

#### **Tag Simple**

```bash
# Crear tag en commit actual
git tag v1.0.0

# Crear tag en commit específico
git tag v1.0.0 abc1234
```

#### **Tag Anotado (Recomendado)**

```bash
# Tag con mensaje
git tag -a v1.0.0 -m "Release version 1.0.0

Features:
- User authentication
- Dashboard analytics
- Email notifications

Bug fixes:
- Fixed memory leak in data processing
- Corrected timezone handling"

# Ver información del tag
git show v1.0.0
```

#### **Subir Tags al Remoto**

```bash
# Subir tag específico
git push origin v1.0.0

# Subir todos los tags
git push origin --tags

# Subir con commits y tags
git push origin main --tags
```

### 📦 **Gestión de Releases**

#### **Listar Versiones**

```bash
# Ver todos los tags
git tag

# Ver tags que coincidan con patrón
git tag -l "v1.*"

# Ver tags ordenados por versión
git tag -l --sort=version:refname
```

#### **Eliminar Tags**

```bash
# Eliminar tag local
git tag -d v1.0.0

# Eliminar tag remoto
git push origin --delete v1.0.0

# O usando la sintaxis alternativa
git push origin :refs/tags/v1.0.0
```

### **Workflow de Release**

```bash
# 1. Finalizar desarrollo
git checkout main
git merge develop

# 2. Actualizar versión en archivos
# package.json, version.txt, etc.

# 3. Commit de versión
git add .
git commit -m "chore: bump version to 1.2.0"

# 4. Crear tag
git tag -a v1.2.0 -m "Release v1.2.0"

# 5. Subir cambios
git push origin main --tags
```

## Changelog y Documentación

### 📋 **Estructura de Changelog**

#### **Formato Recomendado**

```markdown
# Changelog

## [1.2.0] - 2024-03-15

### Added
- Nueva funcionalidad de exportación PDF
- Soporte para autenticación OAuth2
- Dashboard de métricas en tiempo real

### Changed
- Mejorada la velocidad de carga en un 40%
- Actualizada la interfaz de configuración
- Cambiado el formato de fechas a ISO 8601

### Fixed
- Corregido error de memoria en procesamiento masivo
- Solucionado problema de timezone en reportes
- Arreglado bug en validación de formularios

### Deprecated
- Método `oldFunction()` será removido en v2.0.0
- Endpoint `/api/v1/users` usar `/api/v2/users`

### Removed
- Eliminada dependencia obsoleta de jQuery
- Removido soporte para Internet Explorer

### Security
- Parcheada vulnerabilidad XSS en comentarios
- Actualizada biblioteca de encriptación

## [1.1.5] - 2024-03-01

### Fixed
- Hotfix para problema crítico en pagos
```

#### **Categorías Estándar**

- **Added**: Nuevas funcionalidades
- **Changed**: Cambios en funcionalidades existentes
- **Deprecated**: Funcionalidades marcadas como obsoletas
- **Removed**: Funcionalidades eliminadas
- **Fixed**: Corrección de bugs
- **Security**: Cambios relacionados con seguridad

### 📝 **Automatización del Changelog**

#### **Usando Conventional Commits**

```bash
# Instalar herramienta
npm install -g conventional-changelog-cli

# Generar changelog automáticamente
conventional-changelog -p angular -i CHANGELOG.md -s
```

#### **Template de Release Notes**

```markdown
## Release v1.2.0 🚀

### 🎉 New Features
- **Authentication**: OAuth2 integration for Google and GitHub
- **Dashboard**: Real-time analytics dashboard
- **Export**: PDF export functionality for reports

### 🐛 Bug Fixes
- Fixed memory leak in data processing (#234)
- Resolved timezone issues in date calculations (#245)
- Corrected form validation edge cases (#251)

### ⚡ Performance Improvements
- Reduced page load time by 40%
- Optimized database queries
- Implemented lazy loading for images

### 📚 Documentation
- Updated API documentation
- Added migration guide from v1.1.x
- Improved installation instructions

### 🔧 Technical Details
- **Breaking Changes**: None
- **Migration Required**: No
- **Supported Versions**: Node.js 16+, Python 3.8+

### 📦 Downloads
- [Source Code (zip)](link-to-zip)
- [Source Code (tar.gz)](link-to-tar)
- [Windows Installer](link-to-installer)
- [Docker Image](docker-hub-link)
```

## Herramientas Automatizadas

### 🤖 **Semantic Release**

#### **Instalación y Configuración**

```json
// package.json
{
  "devDependencies": {
    "semantic-release": "^19.0.0",
    "@semantic-release/changelog": "^6.0.0",
    "@semantic-release/git": "^10.0.0"
  },
  "release": {
    "branches": ["main"],
    "plugins": [
      "@semantic-release/commit-analyzer",
      "@semantic-release/release-notes-generator",
      "@semantic-release/changelog",
      "@semantic-release/npm",
      "@semantic-release/git"
    ]
  }
}
```

#### **CI/CD Integration**

```yaml
# .github/workflows/release.yml
name: Release
on:
  push:
    branches: [main]
jobs:
  release:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3
      - uses: actions/setup-node@v3
      - run: npm ci
      - run: npm test
      - run: npx semantic-release
        env:
          GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}
          NPM_TOKEN: ${{ secrets.NPM_TOKEN }}
```

### 🏷️ **Bump Version Scripts**

#### **Script de Node.js**

```javascript
// scripts/bump-version.js
const fs = require('fs');
const { execSync } = require('child_process');

const packageJson = require('../package.json');
const currentVersion = packageJson.version;

// Determinar tipo de bump basado en commits
const commits = execSync('git log --oneline $(git describe --tags --abbrev=0)..HEAD').toString();

let bumpType = 'patch';
if (commits.includes('BREAKING CHANGE')) {
  bumpType = 'major';
} else if (commits.includes('feat:')) {
  bumpType = 'minor';
}

// Incrementar versión
execSync(`npm version ${bumpType} --no-git-tag-version`);

const newPackage = require('../package.json');
console.log(`Version bumped from ${currentVersion} to ${newPackage.version}`);

// Crear tag
execSync(`git add package.json`);
execSync(`git commit -m "chore: bump version to ${newPackage.version}"`);
execSync(`git tag -a v${newPackage.version} -m "Release v${newPackage.version}"`);
```

#### **Script de Bash**

```bash
#!/bin/bash
# scripts/release.sh

set -e

# Obtener versión actual
CURRENT_VERSION=$(grep '"version"' package.json | sed 's/.*"version": "\(.*\)".*/\1/')

echo "Current version: $CURRENT_VERSION"

# Preguntar tipo de release
echo "Select release type:"
echo "1) patch (bug fixes)"
echo "2) minor (new features)"  
echo "3) major (breaking changes)"
read -p "Enter choice [1-3]: " choice

case $choice in
  1) TYPE="patch";;
  2) TYPE="minor";;
  3) TYPE="major";;
  *) echo "Invalid choice"; exit 1;;
esac

# Bump version
npm version $TYPE --no-git-tag-version

# Obtener nueva versión
NEW_VERSION=$(grep '"version"' package.json | sed 's/.*"version": "\(.*\)".*/\1/')

echo "New version: $NEW_VERSION"

# Crear commit y tag
git add package.json
git commit -m "chore: bump version to $NEW_VERSION"
git tag -a "v$NEW_VERSION" -m "Release v$NEW_VERSION"

echo "Release v$NEW_VERSION created successfully!"
echo "Push with: git push origin main --tags"
```

## Ejemplos Prácticos

### 📚 **Evolución de un Proyecto**

#### **Fase de Desarrollo**

```
0.1.0  → Primer prototipo funcional
0.2.0  → Agregar autenticación básica  
0.3.0  → Implementar dashboard
0.3.1  → Fix bug en login
0.4.0  → Agregar sistema de roles
0.5.0  → API REST completa
0.6.0  → Interfaz de administración
```

#### **Primera Release Estable**

```
1.0.0  → Primera versión de producción
1.0.1  → Hotfix para bug crítico
1.0.2  → Corrección de seguridad
1.1.0  → Nuevas funcionalidades menores
1.1.1  → Bug fixes varios
1.2.0  → Sistema de notificaciones
```

#### **Major Release**

```
2.0.0  → Rediseño completo de API
       → Cambio de autenticación (JWT → OAuth)
       → Nueva base de datos
       → Breaking changes en endpoints
```

### 🌐 **Casos por Tipo de Proyecto**

#### **API/Backend Service**

```
1.0.0  → API básica funcional
1.1.0  → Nuevos endpoints, mantiene compatibilidad
1.1.1  → Fix en validación de datos
1.2.0  → Rate limiting y caching
2.0.0  → Cambio en estructura de respuestas
2.0.1  → Fix en autenticación OAuth
```

#### **Frontend/Web App**

```
1.0.0  → App funcional para usuarios
1.1.0  → Nueva sección de perfil
1.1.1  → Fix en responsive design
1.2.0  → Dark mode y accesibilidad
2.0.0  → Migración a React 18
2.1.0  → PWA support
```

#### **Biblioteca/Package**

```
1.0.0  → API pública estable
1.0.1  → Bug fix que no cambia API
1.1.0  → Nuevos métodos públicos
1.1.1  → Performance improvements
2.0.0  → Cambios en API pública
2.0.1  → Fix retrocompatibilidad parcial
```

### 🔧 **Pre-releases en Acción**

#### **Ciclo de Release Típico**

```
1.1.0                    → Versión estable actual
1.2.0-alpha.1           → Primeras funcionalidades nuevas
1.2.0-alpha.2           → Más funcionalidades, bugs corregidos
1.2.0-beta.1            → Feature complete, testing extendido
1.2.0-beta.2            → Bug fixes de testing
1.2.0-rc.1              → Candidato final
1.2.0-rc.2              → Solo fixes críticos
1.2.0                   → Release final
```

#### **Hotfix sobre Release**

```
1.2.0                   → Release actual
1.2.0-hotfix.1          → Fix temporal urgente (opcional)
1.2.1                   → Hotfix oficial
```

## Mejores Prácticas

### ✅ **Qué Hacer**

#### **1. Consistencia es Clave**

```bash
# BIEN - Formato consistente
v1.0.0, v1.0.1, v1.1.0, v2.0.0

# MAL - Formatos mixtos  
v1.0, 1.0.1, ver1.1.0, version-2.0.0
```

#### **2. Documenta Cambios Breaking**

~~~markdown
## [2.0.0] - 2024-03-15

### 💥 BREAKING CHANGES
- **API**: Cambiado formato de respuesta de usuarios
  ```json
  // Antes (v1.x)
  { "id": 1, "name": "Juan" }
  
  // Ahora (v2.0)
  { "user": { "id": 1, "name": "Juan" } }
~~~

- **Migration Guide**: [Ver guía de migración](https://claude.ai/chat/migration.md)

```
#### **3. Automatiza Cuando Sea Posible**
- Usa herramientas como semantic-release
- Integra con CI/CD
- Genera changelogs automáticamente
- Valida formato de commits

#### **4. Mantén Versiones Soportadas**
```

Versión    Estado      Soporte hasta 3.x.x      Actual      Indefinido 2.x.x      LTS         2025-12-01
 1.x.x      EOL         2024-06-01

```
#### **5. Usa Pre-releases Apropiadamente**
```bash
# Para testing interno
1.2.0-alpha.1

# Para usuarios early adopters  
1.2.0-beta.1

# Para validación final
1.2.0-rc.1
```

### ❌ **Qué Evitar**

#### **1. Versiones Inconsistentes**

```bash
# MAL
v1.0, v1.0.1, 1.1, ver-1.2.0, V1.3.0

# BIEN
v1.0.0, v1.0.1, v1.1.0, v1.2.0, v1.3.0
```

#### **2. Major Versions sin Documentación**

```bash
# MAL - Sin explicación
2.0.0 → "Major update"

# BIEN - Con detalles
2.0.0 → "API redesign - see migration guide"
```

#### **3. Patches con Breaking Changes**

```bash
# MAL - Breaking change en patch
1.5.3 → 1.5.4 (pero rompe compatibilidad)

# BIEN - Breaking change en major
1.5.3 → 2.0.0
```

#### **4. Pre-releases en Producción**

```bash
# MAL - Pre-release en producción
npm install mypackage@1.0.0-beta.1

# BIEN - Solo versiones estables
npm install mypackage@1.0.0
```

### 🎯 **Consejos Avanzados**

#### **1. Versionado de APIs**

```
/api/v1/users  → Compatible con todas las 1.x.x
/api/v2/users  → Compatible con todas las 2.x.x
```

#### **2. Backward Compatibility**

- Mantén endpoints deprecados por 1-2 major versions
- Avisa con anticipación sobre cambios
- Provide migration tools cuando sea posible

#### **3. Release Notes Efectivas**

- Incluye ejemplos de código
- Menciona performance improvements
- Lista breaking changes claramente
- Agrega guías de migración

## Checklist

### ✅ **Antes de Hacer un Release**

#### **Preparación**

- [ ] Todos los features/bugs están completos
- [ ] Todas las pruebas pasan
- [ ] Documentación actualizada
- [ ] Performance testing realizado
- [ ] Security review completado

#### **Versionado**

- [ ] Número de versión sigue SemVer
- [ ] Tipo de release es correcto (major/minor/patch)
- [ ] Pre-release si es necesario
- [ ] Changelog actualizado con cambios

#### **Documentación**

- [ ] Release notes escritas
- [ ] Breaking changes documentados
- [ ] Migration guide disponible (si necesario)
- [ ] API documentation actualizada

#### **Technical**

- [ ] Build de producción generado
- [ ] Artifacts publicados
- [ ] Docker images tagged
- [ ] CDN assets actualizados

### ✅ **Después del Release**

#### **Comunicación**

- [ ] Anuncio a usuarios enviado
- [ ] Team notificado
- [ ] Social media/blog post publicado
- [ ] Partners/integrations notificados

#### **Monitoring**

- [ ] Deployment monitoreado
- [ ] Error rates normales
- [ ] Performance metrics OK
- [ ] User feedback tracked

#### **Cleanup**

- [ ] Feature branches eliminadas
- [ ] Old releases archived
- [ ] Documentation cleanup
- [ ] Next release planning iniciado

## Configuración en Archivos de Proyecto

### 📦 **package.json (Node.js)**

```json
{
  "name": "mi-proyecto",
  "version": "1.2.3",
  "scripts": {
    "version": "conventional-changelog -p angular -i CHANGELOG.md -s && git add CHANGELOG.md",
    "postversion": "git push origin main --tags",
    "release": "standard-version"
  }
}
```

### 🐍 **setup.py (Python)**

```python
from setuptools import setup

setup(
    name="mi-proyecto",
    version="1.2.3",
    author="Tu Nombre",
    description="Descripción del proyecto",
    long_description=open("README.md").read(),
    classifiers=[
        "Development Status :: 5 - Production/Stable",
        "Programming Language :: Python :: 3.8",
    ],
)
```

### 🔧 **Configuración en CI/CD**

```yaml
# .github/workflows/version.yml
name: Version and Release
on:
  workflow_dispatch:
    inputs:
      version_type:
        description: 'Version type'
        required: true
        default: 'patch'
        type: choice
        options:
          - patch
          - minor
          - major

jobs:
  version:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3
      - run: npm version ${{ inputs.version_type }}
      - run: git push origin main --tags
```

------

## 📞 **Soporte y Recursos**

Para dudas sobre versionado o implementación de estas prácticas:

- Consulta la [documentación oficial de SemVer](https://semver.org/)
- Revisa herramientas como semantic-release
- Contacta al tech lead para casos específicos

**Recuerda**: Un buen versionado es fundamental para la confianza de usuarios y la gestión del proyecto. ¡Úsalo consistentemente desde el día uno!