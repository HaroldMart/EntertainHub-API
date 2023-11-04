# EntertainHub-API

This is an Asp .NET Web API using Entity framework with Code First, it is about entertainment content, you can use this API for your projects to store books, anime, series, movies and other information about your favorite content and connect your frontend applications, the API use the MySQL database to save data.

### Technologies
- ASP .NET Web API
- Entity framework Code First
- MYSQL database

<br/>

You just have to do a few things to get started:

### Start creating your database

You have to change the connectionString in the appsettings.json:

```
 "ConnectionStrings": {
  "defaultConnection": "Server=your_server; Port=3306; Database=your_database; Uid=your_user; Pwd=your_password;"
},

```

Download the API and run the following command in the Nuget Package Manager console:
```
Update-Database
```

Or if you made changes in the project or the Context for MYSQL connection, you can run this first:
```
Add-Migration "my_migration"
```

Then, you can run the Update-database command
<br/>

![image](https://github.com/HaroldMart/EntertainHub-API/assets/93040571/98dc98d8-eb9d-4a1e-9361-3be7c9ed0529)

Easy, you have your own API and you can upload it to hosting, and connect to it with your Frontend Applications ...
