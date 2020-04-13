==============================
README FILE BY JUAN CALDERON
DOCKER TRAINING - SESSION 6
==============================

//1. After install Visual Studio 2019, I created a new NET Core Web Application with Docker support.

//2. I was able to see the dockerfile with the default template, also I can see the Container Tools in the Output windows.

//3. I ran the empty project, the Containers tool appears automatically showing Environments, ports, logs and Files.

==============================
Step 1/5 : FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
 ---> d533dfc81672
Step 2/5 : WORKDIR /app
 ---> Running in b022238133b8
Removing intermediate container b022238133b8
 ---> 148844359954
Step 3/5 : EXPOSE 80
 ---> Running in 9e27ba3b791c
Removing intermediate container 9e27ba3b791c
 ---> 17dc7ea5640a
Step 4/5 : LABEL com.microsoft.created-by=visual-studio
 ---> Running in 13adc137b0f0
Removing intermediate container 13adc137b0f0
 ---> 21d36be22897
Step 5/5 : LABEL com.microsoft.visual-studio.project-name=dockertraining2_juan_calderon
 ---> Running in f2feef068b88
Removing intermediate container f2feef068b88
 ---> 173ecfa6a43d
Successfully built 173ecfa6a43d
Successfully tagged dockertraining2juancalderon:dev
docker run -dt -v "C:\Users\Juan Calderon\onecoremsvsmon\16.5.0102.0:C:\remote_debugger:ro" -v "C:\agile\dockertraining2_juan_calderon:C:\app" -v "C:\agile\dockertraining2_juan_calderon:c:\src" -v "C:\Users\Juan Calderon\.nuget\packages\:c:\.nuget\fallbackpackages2" -v "C:\Program Files\dotnet\sdk\NuGetFallbackFolder:c:\.nuget\fallbackpackages" -e "DOTNET_USE_POLLING_FILE_WATCHER=1" -e "ASPNETCORE_LOGGING__CONSOLE__DISABLECOLORS=true" -e "ASPNETCORE_ENVIRONMENT=Development" -e "NUGET_PACKAGES=c:\.nuget\fallbackpackages2" -e "NUGET_FALLBACK_PACKAGES=c:\.nuget\fallbackpackages;c:\.nuget\fallbackpackages2" -P --name dockertraining2_juan_calderon --entrypoint C:\remote_debugger\x64\msvsmon.exe dockertraining2juancalderon:dev /noauth /anyuser /silent /nostatus /noclrwarn /nosecuritywarn /nofirewallwarn /nowowwarn /fallbackloadremotemanagedpdbs /timeout:2147483646 /LogDebuggeeOutputToStdOut 
56f66a08b36da542dbb1a54bc74044c57b0c560cf605c2b4af5950c254e72f9c
Container started successfully.
========== Finished ==========

//The default web browser was opened automatically to display the Welcome page (Empty project)

//4. The host port was assigned by visual studio : 61160. 
I have verified this with number the docker dashboard, the port number matchs

//5. I can see the next log from the docker dashboard

====================================================================================================================
﻿]0;C:\remote_debugger\x64\msvsmon.exe﻿warn: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository[60]
Storing keys in a directory 'C:\Users\ContainerUser\AppData\Local\ASP.NET\
DataProtection-Keys' that may not be persisted outside of the container. Protected data will be unavailable when container is destroyed.
info: Microsoft.Hosting.Lifetime[0]
Now listening on: http://[::]:80
info: Microsoft.Hosting.Lifetime[0]
Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
Content root path: C:\app
======================================================================================================================

//6. Open cmd as Admin, moving to my solution folder.
//Execute docker command to see the list of containers
docker ps

CONTAINER ID        IMAGE                             COMMAND                    CREATED             STATUS              PORTS                   NAMES
56f66a08b36d        dockertraining2juancalderon:dev   "C:\\remote_debugger\\…"   35 minutes ago      Up 35 minutes       0.0.0.0:61160->80/tcp   dockertraining2_juan_calderon

//Execute docker command to see the list of images
docker images

REPOSITORY                             TAG                                      IMAGE ID            CREATED             SIZE
dockertraining2juancalderon            dev                                      173ecfa6a43d        39 minutes ago      346MB
jcalderon_session5                     latest                                   e0f865a4c396        32 hours ago        524MB
mcr.microsoft.com/dotnet/core/aspnet   3.1-nanoserver-1903                      d533dfc81672        2 weeks ago         346MB
hello-world                            latest                                   b209aa2b650e        4 weeks ago         251MB
microsoft/dotnet                       2.1-aspnetcore-runtime-nanoserver-1803   8b7cf3b42002        5 months ago        521MB

//7. Stop the New Application from Visual Studio 2019
//8. Refresh the web browser to see what happened with the application (http://localhost:61160). Result : is not working...

//9. Create a new container based on dockertraining2juancalderon (From Visual Studio), the new container name is : container_session6
======================================================================================================================
C:\agile\dockertraining2_juan_calderon>docker run --name container_session6 173ecfa6a43d
Microsoft Windows [Version 10.0.18362.720]
(c) 2019 Microsoft Corporation. All rights reserved.

C:\app>
======================================================================================================================
//10. Stop all containers from my docker dashboard, Run the new one. (container_session6)
//This container was stoped automatically... (No containers are running so far)
//This container does not contains an entry point.

//11. Running docker command to create a container (WITH ENTRYPOINT) based on a Dockefile in specific location (Remove if exists)
//NOTE: I was able to run next command successfully (dockerfile template was not affected)
======================================================================================================================
C:\agile\dockertraining2_juan_calderon>docker build -f "C:\agile\dockertraining2_juan_calderon\Dockerfile" --force-rm -t jcalderon_session6 "C:\agile\dockertraining2_juan_calderon"
Sending build context to Docker daemon  4.402MB
Step 1/16 : FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
 ---> d533dfc81672
Step 2/16 : WORKDIR /app
 ---> Using cache
 ---> 148844359954
Step 3/16 : EXPOSE 80
 ---> Using cache
 ---> 17dc7ea5640a
Step 4/16 : FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
3.1-nanoserver-1903: Pulling from dotnet/core/sdk
e0ecf8fc66f5: Already exists                                                                                            744550abe8cf: Pull complete                                                                                             3bffd8ed7b9a: Pull complete                                                                                             a0b1f1e2ac26: Pull complete                                                                                             b3a999a77c88: Pull complete                                                                                             0e67fdfae5cf: Pull complete                                                                                             c5a5e81a2838: Pull complete                                                                                             3ba50d2f7c09: Pull complete                                                                                             Digest: sha256:57e0651e4aa1e24546ab5c76e68e4d362a9608afe3b639a05d7e3136371aed48
Status: Downloaded newer image for mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903
 ---> 18f5170035e2
Step 5/16 : WORKDIR /src
 ---> Running in 6348237d334b
Removing intermediate container 6348237d334b
 ---> f26cff25c9e8
Step 6/16 : COPY ["dockertraining2_juan_calderon.csproj", ""]
 ---> 8ddf75bc2695
Step 7/16 : RUN dotnet restore "./dockertraining2_juan_calderon.csproj"
 ---> Running in c5881caa3abe
  Restore completed in 2.9 sec for C:\src\dockertraining2_juan_calderon.csproj.
Removing intermediate container c5881caa3abe
 ---> 4cd5b056ff4e
Step 8/16 : COPY . .
 ---> c7ff1e5c5e26
Step 9/16 : WORKDIR "/src/."
 ---> Running in 491c924bb582
Removing intermediate container 491c924bb582
 ---> 2eb08cfe60e7
Step 10/16 : RUN dotnet build "dockertraining2_juan_calderon.csproj" -c Release -o /app/build
 ---> Running in 5c53012c7990
Microsoft (R) Build Engine version 16.5.0+d4cbfca49 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 142.48 ms for C:\src\dockertraining2_juan_calderon.csproj.
  dockertraining2_juan_calderon -> C:\app\build\dockertraining2_juan_calderon.dll
  dockertraining2_juan_calderon -> C:\app\build\dockertraining2_juan_calderon.Views.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:10.94
Removing intermediate container 5c53012c7990
 ---> 477afa2783f4
Step 11/16 : FROM build AS publish
 ---> 477afa2783f4
Step 12/16 : RUN dotnet publish "dockertraining2_juan_calderon.csproj" -c Release -o /app/publish
 ---> Running in acad498b9924
Microsoft (R) Build Engine version 16.5.0+d4cbfca49 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 84.5 ms for C:\src\dockertraining2_juan_calderon.csproj.
  dockertraining2_juan_calderon -> C:\src\bin\Release\netcoreapp3.1\dockertraining2_juan_calderon.dll
  dockertraining2_juan_calderon -> C:\src\bin\Release\netcoreapp3.1\dockertraining2_juan_calderon.Views.dll
  dockertraining2_juan_calderon -> C:\app\publish\
Removing intermediate container acad498b9924
 ---> 973ea24ed334
Step 13/16 : FROM base AS final
 ---> 17dc7ea5640a
Step 14/16 : WORKDIR /app
 ---> Running in ce92d301d268
Removing intermediate container ce92d301d268
 ---> 6191113c4a0d
Step 15/16 : COPY --from=publish /app/publish .
 ---> 5a91861a6f6a
Step 16/16 : ENTRYPOINT ["dotnet", "dockertraining2_juan_calderon.dll"]
 ---> Running in bfe1a398cb06
Removing intermediate container bfe1a398cb06
 ---> fb1bbb7a983d
Successfully built fb1bbb7a983d
Successfully tagged jcalderon_session6:latest
======================================================================================================================

//12. In the step 10 we ran a container with no entrypoint and the container stops
//For this example I will try to run the "jcalderon_session6:latest" container (fb1bbb7a983d), because it contains an ENTRYPOINT ["dotnet", "dockertraining2_juan_calderon.dll"]

//13. Running fb1bbb7a983d, this time we defined the port 6090:80
======================================================================================================================
C:\agile\dockertraining2_juan_calderon>docker run --name container2_session6 -p 6090:80 fb1bbb7a983d
warn: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository[60]
      Storing keys in a directory 'C:\Users\ContainerUser\AppData\Local\ASP.NET\DataProtection-Keys' that may not be persisted outside of the container. Protected data will be unavailable when container is destroyed.
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://[::]:80
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\app
======================================================================================================================
//It was verified in my Docker Dashboard, the Container is running in the specified port as expected.
//The "Open in browser" button is enabled for this container, after click, I can see my Welcome page.

//14. I will create a second one.
======================================================================================================================
C:\agile\dockertraining2_juan_calderon>docker run --name container3_session6 -p 6091:80 fb1bbb7a983d
warn: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository[60]
      Storing keys in a directory 'C:\Users\ContainerUser\AppData\Local\ASP.NET\DataProtection-Keys' that may not be persisted outside of the container. Protected data will be unavailable when container is destroyed.
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://[::]:80
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\app
======================================================================================================================

//15. Adding new attributes on appsettings.json
 "AppSettings": {
    "Title":  "Hello from IIS"
  },

//16. Adding IConfiguration to the HomeController.cs constructor

	private readonly IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

//17. Adding a variable for the Title in the ViewBag

	ViewBag.EnvVar = _config.GetSection("AppSettings").GetSection("Title").Value;

//18. Adding html label for the view : Index.cshtml

	<h2 class="display-4">@ViewBag.EnvVar</h2> 

//19. Build a new image with the changes to add the label in the welcome page
======================================================================================================================
C:\agile\dockertraining2_juan_calderon>docker build -f "C:\agile\dockertraining2_juan_calderon\Dockerfile" --force-rm -t jcalderon2_session6 "C:\agile\dockertraining2_juan_calderon"
Sending build context to Docker daemon   4.41MB
Step 1/16 : FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
 ---> d533dfc81672
Step 2/16 : WORKDIR /app
 ---> Using cache
 ---> 148844359954
Step 3/16 : EXPOSE 80
 ---> Using cache
 ---> 17dc7ea5640a
Step 4/16 : FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
 ---> 18f5170035e2
Step 5/16 : WORKDIR /src
 ---> Using cache
 ---> f26cff25c9e8
Step 6/16 : COPY ["dockertraining2_juan_calderon.csproj", ""]
 ---> Using cache
 ---> 8ddf75bc2695
Step 7/16 : RUN dotnet restore "./dockertraining2_juan_calderon.csproj"
 ---> Using cache
 ---> 4cd5b056ff4e
Step 8/16 : COPY . .
 ---> b311fb25ab83
Step 9/16 : WORKDIR "/src/."
 ---> Running in fb8dbc18d879
Removing intermediate container fb8dbc18d879
 ---> 8ca2bc98ab8f
Step 10/16 : RUN dotnet build "dockertraining2_juan_calderon.csproj" -c Release -o /app/build
 ---> Running in 744c904ac4b4
Microsoft (R) Build Engine version 16.5.0+d4cbfca49 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 125.25 ms for C:\src\dockertraining2_juan_calderon.csproj.
  dockertraining2_juan_calderon -> C:\app\build\dockertraining2_juan_calderon.dll
  dockertraining2_juan_calderon -> C:\app\build\dockertraining2_juan_calderon.Views.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:15.19
Removing intermediate container 744c904ac4b4
 ---> 81e9682cec88
Step 11/16 : FROM build AS publish
 ---> 81e9682cec88
Step 12/16 : RUN dotnet publish "dockertraining2_juan_calderon.csproj" -c Release -o /app/publish
 ---> Running in 33c4d56199e7
Microsoft (R) Build Engine version 16.5.0+d4cbfca49 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 79.73 ms for C:\src\dockertraining2_juan_calderon.csproj.
  dockertraining2_juan_calderon -> C:\src\bin\Release\netcoreapp3.1\dockertraining2_juan_calderon.dll
  dockertraining2_juan_calderon -> C:\src\bin\Release\netcoreapp3.1\dockertraining2_juan_calderon.Views.dll
  dockertraining2_juan_calderon -> C:\app\publish\
Removing intermediate container 33c4d56199e7
 ---> fc3c4539ff1e
Step 13/16 : FROM base AS final
 ---> 17dc7ea5640a
Step 14/16 : WORKDIR /app
 ---> Using cache
 ---> 6191113c4a0d
Step 15/16 : COPY --from=publish /app/publish .
 ---> 2ac44d302e78
Step 16/16 : ENTRYPOINT ["dotnet", "dockertraining2_juan_calderon.dll"]
 ---> Running in 931fac98431e
Removing intermediate container 931fac98431e
 ---> 196488b5725e
Successfully built 196488b5725e
Successfully tagged jcalderon2_session6:latest
======================================================================================================================

//20. Create a new container with the new image. (196488b5725e) This image contains the changes to add the new label in the welcome page
======================================================================================================================
C:\agile\dockertraining2_juan_calderon>docker run --name container4_session6 -p 6092:80 196488b5725e
warn: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository[60]
      Storing keys in a directory 'C:\Users\ContainerUser\AppData\Local\ASP.NET\DataProtection-Keys' that may not be persisted outside of the container. Protected data will be unavailable when container is destroyed.
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://[::]:80
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\app
======================================================================================================================
The label is displaying the title value we set in the appsettings.json file

//21. Crea a new container with the new image. (196488b5725e) This time, I will send parameters for the appsettings.
======================================================================================================================
C:\agile\dockertraining2_juan_calderon>docker run --name container5_session6 -p 6093:80 -e "AppSettings:Title"="Hello from Docker" 196488b5725e
warn: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository[60]
      Storing keys in a directory 'C:\Users\ContainerUser\AppData\Local\ASP.NET\DataProtection-Keys' that may not be persisted outside of the container. Protected data will be unavailable when container is destroyed.
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://[::]:80
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\app
======================================================================================================================
The label is displaying the value we set in the command line


==============================
README FILE BY JUAN CALDERON
DOCKER TRAINING - SESSION 6 - Assignment 
==============================

1.- Create a new ASP .NET Core web application with Docker Support. Please create the project as "dockertraining_<name>_<lastname>"
dockertraining2_juan_calderon

2.- Add a appsetting "storename" to define the website name. This will be displayed in home page.
  "AppSettings": {
    "Title": "Hello from IIS",
    "StoreName": "Merida"
  },

3.- Include a readme.txt file in the project. This will contains all docker commands used in the exercise.
Done

4.- Create an Docker image for the project using port 80 for the container.
C:\agile\dockertraining2_juan_calderon>docker build -f "C:\agile\dockertraining2_juan_calderon\Dockerfile" --force-rm -t jcalderon_image "C:\agile\dockertraining2_juan_calderon"

5.- Create a Docker Container using the image. Assign "Site1" as container name and port "8085" to run the container.
C:\agile\dockertraining2_juan_calderon>docker run --name jcalderon_Site1 -p 8085:80 df986c44ea83

6.- Create a Docker Container using the image. Assign "Site2" as container name, port "8086" and "storename" as "Plano".
C:\agile\dockertraining2_juan_calderon>docker run --name jcalderon_Site2 -p 8086:80 -e "AppSettings:StoreName"="Plano" df986c44ea83

7.- Upload the image to Docker Hub using the following credentials:
* docker id: dockertraining2020
* password: dockertraining

Successfully built 2e4a1904dcc8
Successfully tagged dockertraining2juancalderon:latest
========== Build: 1 succeeded, 0 failed, 0 up-to-date, 0 skipped ==========
========== Publish: 1 succeeded, 0 failed, 0 skipped ==========
Successfully pushed docker image with tag 'latest'


9.- Upload project to GitHub. 
https://github.com/jcalderonc/DockerTraining.git

10.- Share your GitHub link. Please include all docker commands used in the exercise to readme.txt file
https://github.com/jcalderonc/DockerTraining

