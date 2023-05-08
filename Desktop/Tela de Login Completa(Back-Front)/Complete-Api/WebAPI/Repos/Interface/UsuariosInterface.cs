using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Repos.Interface
{
    public interface UsuariosInterface
    {
        Task<List<UsuariosModel>> BuscarTodosUsuarios();
        Task<UsuariosModel> BuscarUsuarioPorId(int id);
        Task<UsuariosModel> BuscarUsuarioPorUsuario(string usuario);
        Task<UsuariosModel> AddUsuario(UsuariosModel usuario);
        Task<bool> UsuarioLogin(UsuariosModel usuario);
        Task<UsuariosModel> AtualizarUsuario(UsuariosModel usuario, int id);
        Task<bool> DeletarUsuario(int id);
    }
}
