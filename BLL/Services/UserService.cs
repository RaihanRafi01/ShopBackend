using DAL.Repository;
using DAL.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;

namespace BLL.Services
{
    public class UserService
    {
        private DAL.Repository.UserRepo _DAL;
        private Mapper _Mapper;
        public UserService()
        {
            _DAL = new DAL.Repository.UserRepo();
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>().ReverseMap());
            _Mapper = new Mapper(_config);
        }
        public List<UserDTO> GetAllUsers()
        {
           List<User> users = _DAL.GetAllUsers();
            List<UserDTO> userDTOs = _Mapper.Map<List<User>, List<UserDTO>>(users);
            return userDTOs;
        }
        public UserDTO GetUserById(int id)
        {
            var data = _DAL.GetUserById(id);
            UserDTO userDTO = _Mapper.Map<User, UserDTO>(data);
            if(data == null)
            {
                throw new Exception("Invalid Id");
            }
            return userDTO;

        }
        public void postUser(UserDTO userDTO) 
        { 
            User user = _Mapper.Map<UserDTO, User>(userDTO);
            _DAL.postUser(user);
        }
        public void DeleteUser(int id) 
        {
            
            _DAL.deleteUser(id);
        }
        public UserDTO UpdateUser(int id,UserDTO userDTO) 
        {
            User user = _Mapper.Map<UserDTO, User>(userDTO);
            _DAL.Update(id,user);
            return userDTO;
        }

        public bool Auth(string name, string password)
        {
            //User user = _Mapper.Map<UserDTO, User>(userDTO);
            return _DAL.Auth(name, password);
             
        }

    }
}
