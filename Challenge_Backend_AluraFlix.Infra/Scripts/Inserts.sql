SELECT * FROM challenge_backend_aluraflix.video;

INSERT INTO CATEGORIAS(IdCategoria,TituloCategoria,CorCategoria) VALUES 
(1,'Livre','FFFFFF'),
(2,'Backend','00C86F'),
(3,'Frontend','6BD1FF'),
(4,'Infraestrutura','9CD33B'),
(5,'Marketing','6B5BE2'),
(6,'Mobile','FFBA05'),
(7,'Inovação','FF8C2A'),
(8,'UX & Design','DC6EBE'),
(9,'Data Science','9CD33B');

INSERT INTO VIDEO(tituloVideo, descVideo, urlVideo, imgVideo, idCategoria) VALUES
("Ciclo de vida de componentes React.js | #AluraMais", "Aprenda o que é o ciclo de vida de um componente React.js e como usar no desenvolvimento de projetos.", "https://www.youtube.com/watch?v=jK0uiQ1ZQQQ", "https://img.youtube.com/vi/jK0uiQ1ZQQQ/maxresdefault.jpg", 3),
("O que é Angular e AngularJS? #HipstersPontoTube", "Vanessa Tonini e Mario Souto conversam neste vídeo sobre o Angular  e explicam melhor o que é este framework, como ele surgiu, quando é utilizado e quais são as diferenças entre suas versões. Confira!", "https://www.youtube.com/watch?v=LFlNU30u7d8", "https://img.youtube.com/vi/LFlNU30u7d8/maxresdefault.jpg", 3),
("Lazy Load de Imagens + Animação no Scroll | Performance e efeito com CSS", "Sabia que com 10 linhas de JavaScript e 6 de CSS da pra fazer um efeito M-A-R-A-V-I-L-H-O-S-O de animar as coisas no scroll?", "https://www.youtube.com/watch?v=ql0-0_taZpk", "https://img.youtube.com/vi/ql0-0_taZpk/maxresdefault.jpg", 3),
("O que estudar antes de tentar aprender um Framework JavaScript? (React, Angular, Vue) #ImersaoReact", "Nesse vídeo, vamos fazer um mini render com JavaScript puro na unha, passando pelas principais ideias que os frameworks trabalham enquanto vemos features super importantes do JavaScript pra conseguir trabalhar com outras ferramentas depois.", "https://www.youtube.com/watch?v=QzDjdlF1BQI", "https://img.youtube.com/vi/QzDjdlF1BQI/maxresdefault.jpg", 3),
("5 Frameworks JavaScript Reativos para Conhecer // Vlog #79", "Os frameworks e bibliotecas reativas vieram para revolucionar o desenvolvimento front-end. Por isso escolhemos 5 deles, que em nossa opinião, são os mais indicados para aprender ou ao menos conhecer nesse momento. ", "https://www.youtube.com/watch?v=LOiW_s22tFM", "https://img.youtube.com/vi/LOiW_s22tFM/maxresdefault.jpg", 3);

INSERT INTO VIDEO(tituloVideo, descVideo, urlVideo, imgVideo, idCategoria) VALUES
("O que são anotações no Java? #AluraMais", "O que são aqueles @ que aparecem nos códigos Java? Neste Alura+, o Nico Steppat te explica o que são anotações Java, para que existem e como escreve-las. Assista!", "https://www.youtube.com/watch?v=d7oJwcGJWUk", "https://img.youtube.com/vi/d7oJwcGJWUk/maxresdefault.jpg", 2),
("Classe Object | #AluraMais", "O André Bessa, Instrutor na Escola de Programação aqui na Alura, explica a você tudo sobre Classe Object. Vamos nessa?", "https://www.youtube.com/watch?v=QVsHcjBwlMU", "https://img.youtube.com/vi/QVsHcjBwlMU/maxresdefault.jpg", 2),
("O que é REST? #AluraMais", "Nesse video o instrutor Giovanni Tempobono explica o que é REST, da onde veio e para que serve!", "https://www.youtube.com/watch?v=weQ8ssA6iBU", "https://img.youtube.com/vi/weQ8ssA6iBU/maxresdefault.jpg", 2),
("ASP.NET Core + ASP.NET Identity - Criação do cadastro e login de usuários", "Nesse vídeo, continuamos na implementação do projeto com ASP.NET Identity, dessa vez criando uma camada de Application para separação de algumas estruturas.", "https://www.youtube.com/watch?v=p2zEzafu5po", "https://img.youtube.com/vi/p2zEzafu5po/maxresdefault.jpg", 2),
("Extension Methods no C# | por André Baltieri #balta", "Extension Methods ou métodos de extensão são a forma que temos de adicionar funcionalidades extras a qualquer tipo no C#.", "https://www.youtube.com/watch?v=xQhiv-bmt9o", "https://img.youtube.com/vi/xQhiv-bmt9o/maxresdefault.jpg", 2);