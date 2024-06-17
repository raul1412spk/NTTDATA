@echo off
cd C:\kafka\kafka_2.13-2.8.0
echo HolaKafka | .\bin\windows\kafka-console-producer.bat --topic miTema --bootstrap-server localhost:9092
pause
