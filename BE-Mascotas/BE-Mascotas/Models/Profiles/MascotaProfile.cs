using AutoMapper;
using BE_Mascotas.Models.DTO;

namespace BE_Mascotas.Models.Profiles
{   
    //creamos clase Profile Y mapiamos 
    public class MascotaProfile: Profile
    {
        public  MascotaProfile()
        {
            CreateMap<Mascota, MascotaDTO>();
            CreateMap<MascotaDTO, Mascota>();
        }
    }
}
