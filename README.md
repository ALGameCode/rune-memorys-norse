# rune-memorys-norse
 A runes and vikings memory game
 
 _<https://carolsalvato.itch.io/rune-memory-vikings-adventures>_

## Sobre
Esse projeto é um protótipo em desenvolvimento de um jogo casual para plataforma mobile (Android) com temática viking. A principal mecânica do jogo é o clássico jogo da memória, onde um conjunto de pares de imagens são misturados e virados de cabeça para baixo, para que assim o jogador tente encontrar os pares usando apenas sua memória.

## Sobre o protótipo, suas tecnologias e assets

No desenvolvimento desse jogo foi utilizada a Game Engine Unity (versão 2020.3.7f1 Personal) com a linguagem de programação C#. Os assets de arte usados foram retirados do site _<https://www.kenney.nl/assets>_ e _<https://pixabay.com/pt/>_ todos sob domínio público CC0. As músicas usadas como background music (BGM) foram retiradas de <https://www.free-stock-music.com/viking.html> com seus créditos presentes no projeto.

## Narrativa

A narrativa criada para o jogo em questão coloca o jogador como um Earl (líder viking), e cada jogo é como uma incursão em andamento, onde a cada acerto o jogador ganha tesouros e a cada erro ele perde guerreiros vikings. Para fazer as incursões vikings, um Earl precisa de uma determinada quantidade de guerreiros (dependendo da dificuldade do jogo). Logo, se ele não tiver vikings suficientes, não poderá jogar novamente até que seus guerreiros se recuperem.
Com os tesouros ganhos, o jogador poderá comprar skins (aparências) diferentes para as runas, dentre outros itens que podem ajudá-lo no jogo. Ou poderá também evoluir sua vila para melhorar seus recursos.
 
## Desenvolvimento

Para o desenvolvimento desse protótipo foram criados um conjunto de requisitos gerais, esses foram divididos em partes menores, com objetivo de delimitar o que era possível ser feito dentro do tempo disponível. O conceito geral foi planejado desde o começo para que, durante o desenvolvimento do protótipo, ser possível deixar pré-definido algumas funcionalidades futuras. Por exemplo, no cadastro de runas, foram criadas áreas de cadastro de informações sobre as runas e skins para as mesmas.
A primeira tarefa entregável pré-definida foram apenas as mecânicas principais de um jogo da memória simples, contendo uma mecânica de cadastro de runas, cadastro de dificuldade do jogo e as funções para criar o jogo usando como base as definições da dificuldade escolhida e as runas cadastradas. Na pasta Assets>Configs é possível encontrar as configurações de runas e de dificuldades em uso.
Com a primeira parte em funcionamento, continuei o desenvolvimento buscando implementar as pontuações durante o jogo (ganho de tesouros e perda de vikings), armazenamento de dados local do jogador dentre outras funcionalidades mais simples.
Até o momento da escrita desse documento, o protótipo se encontra na etapa de correções relacionadas as funcionalidades de salvamento, troca de cena e menus. O desenvolvimento será continuado conforme descrito na próxima seção.
 
## Próximos passos
	
Por ser um projeto com início recente alguns erros podem aparecer, mas ao decorrer do desenvolvimento, a versão do Github será atualizada para o mais livre de erros possível. A partir desse ponto, o foco de continuidade no protótipo estará em corrigir os erros já encontrados e finalizar a refatoração de algumas classes que ainda se encontram desorganizadas. Após isso, será feita a implementação das novas funcionalidades, como por exemplo, a loja, onde o jogador poderá comprar skins para as runas dentre outros itens, e a área da vila viking, onde o jogador poderá evoluir seus guerreiros vikings aumentando a quantidade de energia.



