using System;
using Core.Models;
namespace SommerSummarum.Services;

public interface IU18VolunteerService
{
    public Task AddU18Volunteer(U18Volunteer u18VolunteerItem);

    public Task<U18Volunteer[]> FilterByKraew(string kraewnummer);
}