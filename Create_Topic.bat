@echo off
cd C:\kafka\kafka_2.13-2.8.0
.\bin\windows\kafka-topics.bat --create --topic miTema --bootstrap-server localhost:9092 --partitions 1 --replication-factor 1
pause

