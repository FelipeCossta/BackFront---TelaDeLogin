using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repos.Interface;

namespace WebAPI.Repos
{
    public class UsuariosRepositorio : UsuariosInterface
    {
        private readonly UsuariosContext _context;
        public UsuariosRepositorio(UsuariosContext usuariosContext)
        {
            _context = usuariosContext;
        }
        public async Task<List<UsuariosModel>> BuscarTodosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<UsuariosModel> BuscarUsuarioPorId(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UsuariosModel> BuscarUsuarioPorUsuario(string usuario)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == usuario);
        }
        public async Task<UsuariosModel> AddUsuario(UsuariosModel usuario)
        {
          
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuariosModel> AtualizarUsuario(UsuariosModel usuario, int id)
        {
            UsuariosModel UsuarioPorId = await BuscarUsuarioPorId(id);
            if(UsuarioPorId != null)
            {
                throw new Exception($"Usuário para o id: {id} nao foi encontrado! Tente novamente");
            }
            UsuarioPorId.Password = usuario.Password;
            UsuarioPorId.Email = usuario.Email;

            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return UsuarioPorId;
        }
        public async Task<bool> DeletarUsuario(int id)
        {
            UsuariosModel UsuarioPorId = await BuscarUsuarioPorId(id);
            if (UsuarioPorId != null)
            {
                throw new Exception($"Usuário para o id: {id} nao foi encontrado! Tente novamente");
            }
            _context.Remove(UsuarioPorId);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UsuarioLogin(UsuariosModel usuario)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == usuario.Email);

            if(user == null)
            {
                return false;
            }

            if (user.Password != usuario.Password)
            {
                return false;
            }

            return true;
        }
    }
}
