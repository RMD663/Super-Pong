# EBAC - Curso Unity: Do Zero ao Pro

## Módulo 9 - Criando um jogo: Pong - Movimentos básicos

Este projeto consiste no desenvolvimento do clássico jogo Pong na Unity, aplicando o novo Input System para controle local de dois jogadores, física bidimensional e uma arquitetura baseada em eventos para o gerenciamento do fluxo de jogo.

---

### Demonstração do Projeto

![Print do Projeto](print.png)

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

### Estrutura do Código

A lógica do projeto foi modularizada em componentes específicos que se comunicam de forma desacoplada através de eventos.

#### 1. Gerenciamento e Fluxo

* **`GameManager.cs`**: Coordena o ciclo de vida da partida. É responsável por instanciar os elementos na cena (paddles e bola) nas posições corretas e gerenciar o início e encerramento do jogo.
* **`GoalManager.cs`**: Controla as áreas de gatilho (`Trigger`) posicionadas atrás dos paddles para detectar quando a bola sai da tela, disparando o evento que sinaliza qual lado pontuou.
* **`ScoreManager.cs`**: Monitora os eventos de pontuação, atualiza a interface de texto em tempo real via *TextMeshPro* e valida as condições de término da partida.

#### 2. Controle e Mecânicas de Jogo

* **`MovementComponent.cs`**: Gerencia a movimentação física dos bastões. Utiliza o novo *Input System* diretamente via código para capturar os eixos verticais do Player 1 e Player 2 de forma simultânea no mesmo teclado, além de validar as travas de borda para impedir que os objetos saiam da tela.
* **`Ball.cs`**: Aplica uma força física inicial em direções aleatórias no começo da rodada e incrementa a velocidade linear da bola a cada colisão detectada com os paddles.

---

### Conceitos e Recursos Aplicados

* **Arquitetura Baseada em Eventos**: Implementação de `C# Actions` estáticas para a comunicação entre gerentes e objetos, criando um sistema livre de dependências diretas e facilitando o processo de reinício de jogada.
* **Novo Input System**: Configuração de ações diretas (`InputActionAsset`) mapeadas por código, permitindo a leitura fluida e sem conflitos de dois jogadores locais no mesmo dispositivo.
* **Física 2D**: Uso estratégico de componentes `Rigidbody2D` configurados em modo contínuo para evitar falhas de colisão, além do gerenciamento de colisões elásticas e detectores do tipo gatilho.
