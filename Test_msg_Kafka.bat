@echo off
cd C:\kafka\kafka_2.13-2.8.0
.\bin\windows\kafka-console-consumer.bat --topic miTema --bootstrap-server localhost:9092 --from-beginning
pause