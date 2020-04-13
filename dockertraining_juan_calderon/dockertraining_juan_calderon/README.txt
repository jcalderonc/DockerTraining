---------------------------------
---------------------------------
//JCALDERON - Docker Training
SESSION 5 / PART 1
---------------------------------
---------------------------------
//1. Install latest version of Docker for Desktop
//Selected windows containers

//2. Create new Visual Studio project with Docker support.
C:\agile\dockertraining_juan_calderon\dockertraining_juan_calderon

//3. Download the example project files from github.
https://github.com/erikbasto/DockerTraining_Session5.git

//3. Default Dockerfile updated, adding next line.
COPY ./bin/Release/netcoreapp3.1/publish/ app/

//4. Created publish profile based on files
bin\Release\netcoreapp2.1\dockertraining_juan_calderon.dll

//5. Open new project folder from cmd
start -> run -> cmd (Run as admin)
cd..
cd C:\agile\dockertraining_juan_calderon\dockertraining_juan_calderon

//6. Verify if Docker is already installed
docker version

//7. Compile Docker
docker build -t jcalderon_session5:latest .

//8. Error found
error during connect: Post http://%2F%2F.%2Fpipe%2Fdocker_engine/v1.40/build?buildargs=%7B%7D&cachefrom=%5B%5D&cgroupparent=&cpuperiod=0&cpuquota=0&cpusetcpus=&cpusetmems=&cpushares=0&dockerfile=Dockerfile&labels=%7B%7D&memory=0&memswap=0&networkmode=default&rm=1&session=evy9keqxvwiggz1w4bypoofyw&shmsize=0&t=jcalderon_session5%3Alatest&target=&ulimits=null&version=1: open //./pipe/docker_engine: The system cannot find the file specified. In the default daemon configuration on Windows, the docker client must be run elevated to connect. This error may also indicate that the docker daemon is not running.

//FIX #1
start -> service -> Docker Desktop Service restarted

//FIX #2
docker run hello-world

//9. After apply fix #2, I was able to build the new project
ID: e0f865a4c396

//10. Verify if new image has been created
Docker images
---------------------------------------------
REPOSITORY           TAG                                      IMAGE ID            CREATED             SIZE
jcalderon_session5   latest                                   e0f865a4c396        8 minutes ago       524MB
hello-world          latest                                   b209aa2b650e        4 weeks ago         251MB
microsoft/dotnet     2.1-aspnetcore-runtime-nanoserver-1803   8b7cf3b42002        5 months ago        521MB
---------------------------------------------

//11. Create the container for the new image
docker create --name jcalderon_container jcalderon_session5
ID: c6dc4f1dfe2645c773349d3a4fb8c7695f524364b72a89cfe7ce697852525f8f

//12. Verify if the container has been created
CONTAINER ID:c6dc4f1dfe26
IMAGE:jcalderon_session5   
STATUS:Created                                         
NAMES:jcalderon_container

//13. Start jcalderon_container
docker start jcalderon_container
//jcalderon_container is nunning, I have verified from the docker dashboard UI 

---------------------------------
---------------------------------
//JCALDERON - Docker Training
SESSION 5 / PART 2
---------------------------------
---------------------------------
//1. From Visual Studio 2017 -> Select (Docker) from the option list (Run)
//2. Container tools is not available on Visual Studio 2017 -> Download Visual Studio 2019 to continue

