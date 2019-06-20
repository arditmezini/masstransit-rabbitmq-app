echo Run As Administrator otherwise it won't work
echo Uninstalling MassTransit.RabbitMQ.WindowsService.exe

rem  Go to correct path
	cd %~dp0 
	cd ..

echo ---------------------------------------------------
	MassTransit.RabbitMQ.WindowsService.exe uninstall
echo ---------------------------------------------------
echo Done.

TIMEOUT /T 30 /NOBREAK