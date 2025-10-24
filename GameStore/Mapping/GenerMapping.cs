using System;
using GameStore.DTOS;
using GameStore.Entities;

namespace GameStore.Mapping;

public static class GenerMapping
{
    public  static GenerDto ToGenerDto(this Gener gener)
    {
        return new GenerDto(
            gener.Id,
            gener.Name
        );
    }
}
