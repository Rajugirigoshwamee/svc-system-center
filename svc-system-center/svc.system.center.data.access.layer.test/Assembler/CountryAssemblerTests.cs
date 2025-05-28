using FluentAssertions;
using svc.birdcage.parrot.Masters;
using svc.system.center.data.access.layer.Assembler.Public;
using svc.system.center.domain.Commands.Country;
using svc.system.center.domain.Interfaces.Assemblers.Public;

namespace svc.system.center.data.access.layer.test.Assembler;

public class CountryAssemblerTests
{
    private readonly ICountryAssembler _assembler = new CountryAssembler();

    [Fact]
    public void WriteDTO_ValidEntity_ReturnsCorrectDto()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        var entity = new Countries
        {
            Id = id,
            Name = "India",
            Code = "IN",
            FlagUrl = "https://flags.com/in.png",
            MobileCode = "+91"
        };

        // Act
        var result = _assembler.WriteDTO(entity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(entity.Id, result.Id);
        Assert.Equal(entity.Name, result.Name);
        Assert.Equal(entity.Code, result.Code);
        Assert.Equal(entity.FlagUrl, result.FlagUrl);
        Assert.Equal(entity.MobileCode, result.MobileCode);
    }

    [Fact]
    public void WriteDTO_NullEntity_ReturnsNull()
    {
        var result = _assembler.WriteDTO(null);
        Assert.Null(result);
    }

    [Fact]
    public void WriteEntity_FromAddCommand_ReturnsCorrectEntity()
    {
        // Arrange
        var command = new AddCountryCommand("Brazil", "BR", "+55", "https://flags.com/br.png");

        // Act
        var result = _assembler.WriteEntity(command);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(command.Name, result.Name);
        Assert.Equal(command.Code, result.Code);
        Assert.Equal(command.FlagUrl, result.FlagUrl);
        Assert.Equal(command.MobileCode, result.MobileCode);
    }

    [Fact]
    public void WriteEntity_FromAddCommand_NullCommand_ReturnsNull()
    {
        var result = _assembler.WriteEntity((AddCountryCommand)null);
        Assert.Null(result);
    }

    [Fact]
    public void WriteEntity_FromUpdateCommand_ReturnsCorrectEntity()
    {
        // Arrange
        var id = Guid.NewGuid();
        var command = new UpdateCountryCommand(id, "USA", "US", "+1", "https://flags.com/us.png");

        // Act
        var result = _assembler.WriteEntity(command);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(command.Id, result.Id);
        Assert.Equal(command.Name, result.Name);
        Assert.Equal(command.Code, result.Code);
        Assert.Equal(command.FlagUrl, result.FlagUrl);
        Assert.Equal(command.MobileCode, result.MobileCode);
    }

    [Fact]
    public void WriteEntity_FromUpdateCommand_NullCommand_ReturnsNull()
    {
        var result = _assembler.WriteEntity((UpdateCountryCommand)null);
        Assert.Null(result);
    }
}
