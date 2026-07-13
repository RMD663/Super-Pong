# EBAC - Curso Unity: Do Zero ao Pro

## Módulo 9 - Criando um jogo: Pong - Movimentos básicos

Este projeto consiste no desenvolvimento do clássico jogo Pong na Unity, aplicando o novo Input System para controle local de dois jogadores, física bidimensional e uma arquitetura baseada em eventos para o gerenciamento do fluxo de jogo.

---

### Demonstração do Projeto

![Print do Projeto](print_c.png)

---

### Controles do Jogo

O mapeamento foi configurado no mesmo teclado para permitir partidas locais de forma simultânea e sem conflitos:

* **Jogador 1**: 
  * Movimento para cima: `W`
  * Movimento para baixo: `S`

* **Jogador 2**: 
  * Movimento para cima: `Seta para Cima`
  * Movimento para baixo: `Seta para Baixo`



---

### Conceitos e Recursos Aplicados

**Arquitetura Baseada em Eventos**  
  Implementação de `C# Actions` estáticas para a comunicação entre gerentes e objetos, criando um sistema livre de dependências diretas e facilitando o processo de reinício de jogada.

  **Novo Input System**  
  Configuração de ações diretas (`InputActionAsset`) mapeadas por código, permitindo a leitura fluida e sem conflitos de dois jogadores locais no mesmo dispositivo.

  **Física 2D**  
  Uso estratégico de componentes `Rigidbody2D` configurados em modo contínuo para evitar falhas de colisão, além do gerenciamento de colisões elásticas e detectores do tipo gatilho.

  **Persistência de Dados com PlayerPrefs**  
  Armazenamento local de nomes dos jogadores, histórico de vitórias e estatísticas, garantindo que as informações sejam mantidas entre sessões de jogo.

  **Interface com TextMeshPro**  
  Utilização de texto dinâmico e interativo para exibição de pontuações, nomes e mensagens de vitória.

  **Scriptable Objects**  
  Uso de `PaddleData` para centralizar as configurações dos paddles (nome, cor, jogador) e facilitar a edição e reutilização dos dados.

  **Inteligência Artificial**  
  Implementação básica de um adversário controlado por IA para o modo singleplayer.

  **Gerenciamento de Cenas**  
  Navegação entre cenas de menu e jogo, com fluxo completo de início, partida e fim de jogo.

  **Sistema de Reset**  
  Funcionalidade completa para reiniciar o jogo e limpar todos os dados salvos, proporcionando uma experiência limpa para novos jogadores.
