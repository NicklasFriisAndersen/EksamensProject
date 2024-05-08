using System;
using Core.Models;
namespace ServerAPI.Repositories;

public interface IU18VolunteerRepository
{
    public void insertOneU18Volunteer(U18Volunteer u18Volunteer);
    
    public List<U18Volunteer> sortSignatureByU18Kraevnummer(string kraevnummerU18);
}