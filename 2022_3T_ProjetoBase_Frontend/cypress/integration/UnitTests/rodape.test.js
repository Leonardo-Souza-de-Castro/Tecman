//describe => é a descrição, a função que vai ser executada

describe('Componente - Rodapé', () => {

    //Pré-Condição para todos os testes
    //Indica que devemos abrir o navegador e qual pagina vai ser acessada
    beforeEach(() => {
        cy.visit('http://localhost:3000')
    })

    //Descrição
    it('Deve existir uma tag footer no corpo do documento', () => {
        //Pré-Condição


        //Procedimento
        cy.get('footer').should('exist') //aqui ele vai dentro da pagina que a gente especificou ver se a tag footer existe.

        //Resultado Esperado
    })


    it('Deve conter o texto Escola Senai de Informatica', () =>{
        cy.get('.rodapePrincipal section div p').should('have.text', 'Escola SENAI de Informática - 2021')
    })

    it('Deve verificar se footer esta visivel e se possui uma classe chamada rodapePrincipal', () =>{
        cy.get('footer').should('be.visible').and('have.class', 'rodapePrincipal')
    })
})