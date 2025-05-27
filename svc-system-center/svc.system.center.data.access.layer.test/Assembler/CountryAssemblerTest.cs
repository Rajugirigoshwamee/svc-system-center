using FluentAssertions;
using svc.birdcage.parrot.Masters;
using svc.system.center.data.access.layer.Assembler.Public;
using svc.system.center.domain.Commands.Country;
using svc.system.center.domain.Interfaces.Assemblers.Public;

namespace svc.system.center.data.access.layer.test.Assembler
{
    public class CountryAssemblerTest
    {
        private readonly ICountryAssembler _assembler= new CountryAssembler();

         [Fact]
        public void WriteDTO_Should_Map_Countries_To_GetCountryDto()
        {
            // Arrange
            var country = new Countries
            {
                Name = "USA",
                Code = "US",
                FlagUrl = "http://example.com/flags/us.png",
                MobileCode = "+1"
            };

            // Act
            var result = _assembler.WriteDTO(country);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("USA");
            result.Code.Should().Be("US");
            result.FlagUrl.Should().Be("http://example.com/flags/us.png");
            result.MobileCode.Should().Be("+1");
        }

        [Fact]
        public void WriteEntity_With_AddCountryCommand_Should_Map_To_Countries()
        {
            // Arrange
            var command = new AddCountryCommand("Canada", "CA", "+1", "http://example.com/flags/ca.png");             

            // Act
            var result = _assembler.WriteEntity(command);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("Canada");
            result.Code.Should().Be("CA");
            result.FlagUrl.Should().Be("http://example.com/flags/ca.png");
            result.MobileCode.Should().Be("+1");
        }

        [Fact]
        public void WriteEntity_With_Null_AddCountryCommand_Should_Return_Null()
        {
            // Act
            var result = _assembler.WriteEntity((AddCountryCommand)null);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void WriteEntity_With_UpdateCountryCommand_Should_Map_To_Countries()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var command = new UpdateCountryCommand(id,"Germany","DE", "+49","http://example.com/flags/de.png");

            // Act
            var result = _assembler.WriteEntity(command);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(id);
            result.Name.Should().Be("Germany");
            result.Code.Should().Be("DE");
            result.FlagUrl.Should().Be("http://example.com/flags/de.png");
            result.MobileCode.Should().Be("+49");
        }
    }
}
