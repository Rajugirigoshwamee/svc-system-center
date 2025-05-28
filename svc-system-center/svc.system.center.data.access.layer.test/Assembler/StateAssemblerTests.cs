using FluentAssertions;
using svc.system.center.data.access.layer.Assembler.Public;
using svc.system.center.domain.Commands.Country;

namespace svc.system.center.data.access.layer.test.Assembler;

public class StateAssemblerTests
{
    private readonly StateAssembler _assembler;

    public StateAssemblerTests()
    {
        _assembler = new StateAssembler();
    }

    [Fact]
    public void WriteEntity_FromAddStateCommand_ReturnsCorrectState()
    {
        // Arrange
        var countryId=Guid.NewGuid();
        var command = new AddStateCommand("Gujarat","GJ",countryId);

        // Act
        var result = _assembler.WriteEntity(command);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(command.Name, result.Name);
        Assert.Equal(command.Code, result.Code);
        Assert.Equal(command.CountryId, result.CountryId);
    }

    [Fact]
    public void WriteEntity_FromUpdateStateCommand_ReturnsCorrectState()
    {
        // Arrange
        var id= Guid.NewGuid();
        var countryId=Guid.NewGuid();
        var command = new UpdateStateCommand(id,"California","CA",countryId);

        // Act
        var result = _assembler.WriteEntity(command);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(command.Id, result.Id);
        Assert.Equal(command.Name, result.Name);
        Assert.Equal(command.Code, result.Code);
        Assert.Equal(command.CountryId, result.CountryId);
    }

    [Fact]
    public void WriteEntity_WithNullAddStateCommand_ShouldReturnNull()
    {
        // Act
        var result = _assembler.WriteEntity((AddStateCommand)null);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void WriteEntity_WithNullUpdateStateCommand_ShouldReturnNull()
    {
        // Act
        var result = _assembler.WriteEntity((UpdateStateCommand)null);

        // Assert
        result.Should().BeNull();
    }
}
