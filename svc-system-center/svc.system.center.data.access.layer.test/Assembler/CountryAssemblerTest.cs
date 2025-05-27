using svc.system.center.data.access.layer.Assembler.Public;
using svc.system.center.domain.Commands.Country;
using svc.system.center.domain.Interfaces.Assemblers.Public;

namespace svc.system.center.data.access.layer.test.Assembler
{
    public class CountryAssemblerTest
    {
        private readonly ICountryAssembler _assembler= new CountryAssembler();


        [Fact]
        public void AddCountry_Command_Should_Map_Country_Entity_Success()
        {
            // Arrange
            var user = new AddCountryCommand("INDIA","IND","+91","test");

            // Act
            var entity = _assembler.WriteEntity(user);

            // Assert
            Assert.NotNull(entity);
            Assert.Equal("INDIA", entity.Name);
            Assert.Equal("IND", entity.Code);
            Assert.Equal("+91", entity.MobileCode);
            Assert.Equal("test", entity.FlagUrl);
        }

        [Fact]
        public void AddCountry_Command_Should_Map_Country_Entity_If_AddCountryCommand_Is_Null()
        {
            // Act
            var entity = _assembler.WriteEntity((AddCountryCommand)null);

            // Assert
            Assert.Null(entity);
        }
    }
}
