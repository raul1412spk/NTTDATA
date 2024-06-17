package com.rn.nttdata.clientepersona.service;

import com.rn.nttdata.clientepersona.entity.Cliente;
import com.rn.nttdata.clientepersona.repository.ClienteRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ClienteService {

    @Autowired
    private ClienteRepository clienteRepository;

    public List<Cliente> findAll() {
        return clienteRepository.findAll();
    }

    public Cliente findById(Long id) {
        return clienteRepository.findById(id).orElseThrow(() -> new RuntimeException("Cliente no encontrado"));
    }

    public Cliente save(Cliente cliente) {
        return clienteRepository.save(cliente);
    }

    public Cliente update(Long id, Cliente cliente) {
        Cliente existingCliente = clienteRepository.findById(id).orElseThrow(() -> new RuntimeException("Cliente no encontrado"));
        existingCliente.setNombre(cliente.getNombre());
        existingCliente.setGenero(cliente.getGenero());
        existingCliente.setEdad(cliente.getEdad());
        existingCliente.setDireccion(cliente.getDireccion());
        existingCliente.setTelefono(cliente.getTelefono());
        existingCliente.setPassword(cliente.getPassword());
        existingCliente.setUsuario(cliente.getUsuario());
        existingCliente.setEstado(cliente.getEstado());
        return clienteRepository.save(existingCliente);
    }

    public void delete(Long id) {
        clienteRepository.deleteById(id);
    }
}
