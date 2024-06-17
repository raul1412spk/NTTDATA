package com.rn.nttdata.clientepersona.repository;

import com.rn.nttdata.clientepersona.entity.Persona;
import org.springframework.data.jpa.repository.JpaRepository;

public interface PersonaRepository extends JpaRepository<Persona, Long> {
}