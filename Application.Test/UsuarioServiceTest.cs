namespace Application.Test
{
    public class UsuarioServiceTest
    {
        [Theory]
        [InlineData(true,null,"vocejatrazeu")]
        [InlineData(true,"","vocejatrazeu")]
        [InlineData(true,"teste@teste.com",null)]
        [InlineData(true,"teste@teste.com","")]
        [InlineData(false,"teste@teste.com","vocejatrazeu")]
        public void CriarUsuario_QuandoDadosInvalidos_DeveLancarExcecao(bool lancarExcecao, string email, string senha)
        {
            //GIVEN


            //WHEN


            //THEN

        }
    }
}