describe('Ponta a Ponta', () =>{

    beforeEach(() => {
        cy.visit('http://localhost:3000')
    })

    it('Deve logar e inserir a imagem OCR retornando o valor correto da mesma', () => {

        cy.get('.cabecalhoPrincipal-nav-login').should('exist')
        cy.get('.cabecalhoPrincipal-nav-login').click()

        cy.get('.input__login').first().type('paulo@email.com')
        cy.get('.input__login').last().type('123456789')
        cy.get('#btn__login').click()

        cy.get('input[type=file]').first().selectFile('src/assets/testes/equipamento.jpeg')
        
        cy.wait(3000)

        cy.get('#codigoPatrimonio').should('have.value', '1202515')

        cy.get('#nomePatrimonio').type('produto 1')
        cy.get('[type="checkbox"]').check()

        cy.get('input[type=file]').last().selectFile('src/assets/testes/lixeira.jpeg')

        cy.get('#btn__cadastro').should('exist')
        cy.get('#btn__cadastro').click()

        cy.wait(3000)

        cy.get('.excluir').last().should('exist')
        cy.get('.excluir').last().click()
    })

})