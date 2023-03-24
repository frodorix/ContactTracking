# ContactTracking
In Appsettings.conf you can enable SQL database Configurations.

"Persistence": {
    "UseSql": "N",
    "Seed": "Y"
  }

For Sql Server:
1. set "UseSql": "Y".
2. start a Power shell console.
3. enter to ContactTracking/Tools
4. Run:
    ./BUILDRunSQLServer.ps1
5. wait while a docker container is created, also the database is created and migrations executed
6. run MvcWebApp project with IIS Express
