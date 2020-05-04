**********************************
**********************************
JUAN CALDERON - DOCKER COMPOSE
**********************************
**********************************

1.- Create a new ASP .NET Core web api with Docker Support. Please create the project as "dockertraining_compose_<name>_<lastname>"

2.- Add an entity and code to persist the information related to this entity. You can use Entity Framework, NHibernate or another ORM.

For DB, you could  use PostgreSQL, MySQL, MariaDB or SQL Server for linux.
3.- Add a new controller with a get, add and delete operations using http verbs.

4.- Add Docker Compose support to the project considering:

4.1.- For DB:

The container must be named "database_container"
The host port must be 3018.
The data cannot be deleted, even if the container is stopped.
4.2- For api:

The container must be named "api_container"
The host port must be 8091
5.- Upload the image to Docker Hub using the following credentials:

* docker id: dockertraining2020

* password: dockertraining

6- Upload project to GitHub. 

10.- Share your GitHub link. Please include all docker commands used in the exercise to readme.txt file of Github.


**********************************
**********************************

1.- Verify if we have the image for MySQL

C:\agile\dockertraining_compose_juan_calderon_lx>docker images
REPOSITORY                             TAG                 IMAGE ID            CREATED             SIZE
dockertrainingcomposejuancalderonlx    dev                 fa3ca67685f5        34 hours ago        207MB
mcr.microsoft.com/dotnet/core/aspnet   3.1-buster-slim     79e79777c3bf        11 days ago         207MB


2.- I dont have it, so download the image

C:\agile\dockertraining_compose_juan_calderon_lx>docker pull mysql
Using default tag: latest
latest: Pulling from library/mysql
54fec2fa59d0: Already exists                                                                                            bcc6c6145912: Pull complete                                                                                             951c3d959c9d: Pull complete                                                                                             05de4d0e206e: Pull complete                                                                                             319f0394ef42: Pull complete                                                                                             d9185034607b: Pull complete                                                                                             013a9c64dadc: Pull complete                                                                                             42f3f7d10903: Pull complete                                                                                             c4a3851d9207: Pull complete                                                                                             82a1cc65c182: Pull complete                                                                                             a0a6b01efa55: Pull complete                                                                                             bca5ce71f9ea: Pull complete                                                                                             Digest: sha256:61a2a33f4b8b4bc93b7b6b9e65e64044aaec594809f818aeffbff69a893d1944
Status: Downloaded newer image for mysql:latest
docker.io/library/mysql:latest

3.- Create the volumen to storage the data of the data base

C:\agile\dockertraining_compose_juan_calderon_lx>docker volume create mysql_volume_jc
mysql_volume_jc


4.- Create the container database_container_jc for mysql using the volume mysql_volume_jc and port 3018

C:\agile\dockertraining_compose_juan_calderon_lx>docker run --name database_container_jc -e MYSQL_RANDOM_ROOT_PASSWORD=yes -e MYSQL_DATABASE=fooddb -e MYSQL_USER=test -e MYSQL_PASSWORD=123456 -v mysql_volume_jc:/var/lib/mysql -p 3018:3306 -d mysql
914c0474a58c1ae96c43ee4491edc47dc76124f0f01f09f38c92ebb0b9a4ef35

5.- I have created a new API project with docker support for linux due to mysql is based on linux
Adding nuget packages:
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Pomelo.EntityFrameworkCore.MySql

6.- Adding Entity information
Adding classes:
C:\agile\dockertraining_compose_juan_calderon_lx\Controllers\FoodController.cs
C:\agile\dockertraining_compose_juan_calderon_lx\Models\Food.cs
C:\agile\dockertraining_compose_juan_calderon_lx\Models\FoodContext.cs

7.- Adding string connection to appsettings.json
 "ConnectionStrings": {
    "FoodDB": "Server=localhost;Port=3018;Database=fooddb; Uid=test; Pwd=123456"
  },

8.- Startup.cs updated to initialize and connect the database

9.- Initialize migrations
dotnet ef migrations add Initial

10.- I my case I was having error because the tool appearently is not installed
I ran this command to instal....

PM> dotnet tool install --global dotnet-ef --version 3.0.0
Since you just installed the .NET Core SDK, you will need to reopen the Command Prompt window before running the tool you installed.
You can invoke the tool using the following command: dotnet-ef
Tool 'dotnet-ef' (version '3.0.0') was successfully installed.

11.- Trying to create the migration again
PM> dotnet ef migrations add Initial
The EF Core tools version '3.0.0' is older than that of the runtime '3.1.3'. Update the tools for the latest features and bug fixes.
Done. To undo this action, use 'ef migrations remove'
PM> 


12.- Testing with IIS Express
Exception thrown: 'MySql.Data.MySqlClient.MySqlException' in Microsoft.EntityFrameworkCore.dll
An exception of type 'MySql.Data.MySqlClient.MySqlException' occurred in Microsoft.EntityFrameworkCore.dll but was not handled in user code
Host '172.17.0.1' is not allowed to connect to this MySQL server

13.-Installing MySQL Workbench to check if the database is running. 
# mysql -u test -p
Enter password:
ERROR 1045 (28000): Access denied for user 'test'@'localhost' (using password: YES)
#

13.- Create image from project
C:\agile\dockertraining_compose_juan_calderon_lx>docker build -f "C:\agile\dockertraining_compose_juan_calderon_lx\Dockerfile" --force-rm -t compose_jc_img "C:\agile\dockertraining_compose_juan_calderon_lx"
Sending build context to Docker daemon  36.86kB

14.- Create api-container linked to database-container
C:\agile\dockertraining_compose_juan_calderon_lx>docker run --name api_container_jc -p 8091:80 -e "ConnectionStrings:FoodDB"="Server=localhost;Port=3018;Database=fooddb; Uid=test; Pwd=123456" --link database_container_jc -it compose_jc_img
fail: Microsoft.EntityFrameworkCore.Database.Connection[20004]
      An error occurred using the connection to database '' on server 'localhost'.
fail: Microsoft.EntityFrameworkCore.Database.Connection[20004]
      An error occurred using the connection to database '' on server 'localhost'.
fail: Microsoft.EntityFrameworkCore.Database.Connection[20004]
      An error occurred using the connection to database '' on server 'localhost'.
fail: Microsoft.EntityFrameworkCore.Database.Connection[20004]
      An error occurred using the connection to database '' on server 'localhost'.
fail: Microsoft.EntityFrameworkCore.Database.Connection[20004]
      An error occurred using the connection to database '' on server 'localhost'.
fail: Microsoft.EntityFrameworkCore.Database.Connection[20004]
      An error occurred using the connection to database '' on server 'localhost'.



