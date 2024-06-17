package com.rn.nttdata.clientepersona.service;

import org.springframework.kafka.annotation.KafkaListener;
import org.springframework.stereotype.Service;

@Service
public class KafkaConsumerService {

    @KafkaListener(topics = "miTema", groupId = "grupoId")
    public void listen(String message) {
        System.out.println("Mensaje recibido: " + message);
    }
}
