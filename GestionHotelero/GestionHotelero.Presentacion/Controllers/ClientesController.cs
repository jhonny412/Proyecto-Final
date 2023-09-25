using GestionHotelero.Entities;
using GestionHotelero.Entities.Helper.Entities;
using GestionHotelero.Presentacion.Models;
using GestionHotelero.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionHotelero.Presentacion.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IActionResult> Index(string? nombre)
        {
            ViewBag.Nombre = nombre;

            return View(new ClienteView
            {
                Clientes = await _clienteRepository.GetAllAsync(nombre)
            });
        }

        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Create()
        {
            return View(new ClienteViewModel()
            {

            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Create(ClienteViewModel request)
        {
            await _clienteRepository.AddAsync(
                new Cliente
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    NroDocumento = request.NroDocumento,
                    Email = request.Email,
                    Telefono = request.Telefono,
                    Direccion = request.Direccion,
                    FechaNacimiento = request.FechaNacimiento
                    //Condicion = request.Condicion
                });

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _clienteRepository.FindByIdAsync(id);
            if (entity is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = new ClienteViewModel
            {
                IdCliente = entity.IdCliente,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                Email = entity.Email,
                Telefono = entity.Telefono,
                Direccion = entity.Direccion,
                FechaNacimiento = entity.FechaNacimiento,
                //Condicion = entity.Condicion,
                NroDocumento = entity.NroDocumento,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Edit(ClienteViewModel request)
        {
            var cliente = await _clienteRepository.FindByIdAsync(request.IdCliente);

            if (cliente is null)
            {
                ModelState.AddModelError("ID", "No se encontro el registro");
                return View();
            }
            cliente.IdCliente = request.IdCliente;
            cliente.Nombre = request.Nombre;
            cliente.Apellido = request.Apellido;
            cliente.Email = request.Email;
            cliente.Telefono = request.Telefono;
            cliente.Direccion = request.Direccion;
            cliente.FechaNacimiento = request.FechaNacimiento;
            //cliente.Condicion = request.Condicion;
            cliente.NroDocumento = request.NroDocumento;

            await _clienteRepository.UpdateAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteRepository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}