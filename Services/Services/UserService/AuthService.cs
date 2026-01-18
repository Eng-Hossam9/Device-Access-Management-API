using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using Services.Helper;
using Services.InterFaces;
using Services.Queries.User;

public class AuthService
{
    private readonly IUnitOfWork _uow;
    private readonly JwtAuth _jwt;

    public AuthService(IUnitOfWork uow, JwtAuth jwt)
    {
        _uow = uow;
        _jwt = jwt;
    }

    public async Task<string> Login(LoginUserQuery dto)
    {
        var user = await _uow
            .Repository<Guid, Users>()
            .GetAll()
            .FirstOrDefaultAsync(x => x.Email == dto.Email);

        if (user == null)
            throw new Exception("Invalid email or password");

        var valid = PasswordHasher.Verify(dto.Password, user.PasswordHash);

        if (!valid)
            throw new Exception("Invalid email or password");

        return _jwt.GenerateToken(
            user.Id.ToString(),
            user.Email,
            user.Role,
            user.Name
        );
    }
}
