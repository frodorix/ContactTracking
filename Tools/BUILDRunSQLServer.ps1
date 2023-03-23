#$source = "src/db"
#$destino = "Tools/ServerMSSQL"
$network="frodorix-candidate-network" 
$sqlservercontainer="frodorix-sqlserver"
$apicontainer="frodorix-candidate-api"
$apiimage="frodo-candidate-api:latest"
$sqlimage="frodo-mssql-image:latest"

docker network create -d bridge $network

#Copy-Item -Path $source -Filter "*.sql" -Recurse -Destination $destino -Container -force
echo "##############################################"
echo "######  CREAMOS SQL SERVER CONTAINER #########"
echo "##############################################"
#######elimiar imagen anterior
$haySQL=$(docker images $sqlimage -q)
if($haySQL){
	docker rmi --force $haySQL
}

docker build -t $sqlimage MSSql\.

#iniciar container
docker run -d --name $sqlservercontainer  -p 8433:1433 --network $network $sqlimage


