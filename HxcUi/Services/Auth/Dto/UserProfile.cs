using HxcUi.Enums;

namespace HxcUi.Services.Auth.Dto;

public class UserProfile(Guid userId, string userName, Gender gender, string? avatar = null)
{
    public Guid UserId { get; set; } = userId;
    public string UserName { get; set; } = userName;
    public Gender Gender { get; set; } = gender;
    public string? Avatar { get; set; } = avatar;
}