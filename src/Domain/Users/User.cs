﻿using SharedKernel;

namespace Domain.Users;

public sealed class User : Entity
{
    private User(Guid id, Email email, Name name, bool hasPublicProfile)
        : base(id)
    {
        Email = email;
        Name = name;
        HasPublicProfile = hasPublicProfile;
    }

    private User()
    {
    }

    public Email Email { get; private set; }

    public Name Name { get; private set; }

    public string IdentityId { get; private set; } = string.Empty;

    public bool HasPublicProfile { get; private set; }

    public static User Create(Email email, Name name, bool hasPublicProfile)
    {
        var user = new User(Guid.NewGuid(), email, name, hasPublicProfile);

        user.Raise(new UserCreatedDomainEvent(user.Id));

        return user;
    }

    public void SetIdentityId(string identityId)
    {
        IdentityId = identityId;
    }
}
