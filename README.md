## Instalación

### Paso 1
Primero clonamos el siguiente repositorio https://github.com/hermy991/claro_tech_test1.git con el siguiente comando.

```sh
git clone https://github.com/hermy991/claro_tech_test1.git
```

### Paso 2
Entramos a la carpeta del repositorio.

```sh
cd claro_tech_test1
```

### Paso 3
Configuramos la base de datos en el siguiente archivo `appsettings.json`

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "Data": {
    "ConnectionString": "server=.\\LAB;database=CLARO_TECH_TEST1;user=hermy991;password=******;",
    "ServerVersion": "8.0.21"
  }
}
```

### Paso 4
Instalamos la herramienta `dotnet` en la siguiente dirección url https://dotnet.microsoft.com/download, se recomienda instalar la versión 5 en adelante, 

### Paso 5
Instalamos el CLI de entity framework `dotnet tool install --global dotnet-ef`

```sh
dotnet tool install --global dotnet-ef
```

### Paso 6
Ejecutamos el siguiente comando para registrar las entidades en la base de datos.
```sh
dotnet ef database update --verbose
```

### Paso 7
Despues del registro exitoso de las entidades en la base de datos, corremos el aplicativo en desarrollo.
```sh
dotnet run ClaroTechTest1.csproj
```

### Paso 8
Lo siguiente es utilizar el navegador (Chrome, Mozilla, etc) y dirigirse al siguiente url http://localhost:5000.



