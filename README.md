# TeacherAdminAPI
This project is an ASP.NET Core web api for teachers to be able to perform administrative functions for their students. 
Teachers and students are identified by their email addresses.

## Getting Started

Clone the repository into visual studio or visual studio code.
```shell
git clone https://github.com/Yadanar25/TeacherAdminAPI.git
```

### Web API

1. Install [.NET core 3.1](https://www.microsoft.com/net/core). 

2. Install MySQL and Set up MySQL server. Create Database and name it to 'teacherstudentdb'. Please change username and password accordingly in 'appsettings.json'

3. Run script for database update from visual studio. Go to Tools -> Packet Manager Console -> run 'Update-Database'. Please make sure local database is running.

4. Deploy api. From Visual Studio, just press 'IISExpress' to deploy api.

5. Ready for testing.

### Swagger

In order to acces the api swagger documentation, just deploy api locally and the browser will pop up with swagger documentation.
