# Expoverse 🏛️🧬
**Reconstituição Museológica Interativa e Preservação Digital em Realidade Virtual Nativa com 3D Gaussian Splatting.**

![Unity](https://img.shields.io/badge/Unity-6.0%2B-black?style=flat-square&logo=unity)
![Meta Quest](https://img.shields.io/badge/Platform-Meta%20Quest-blue?style=flat-square&logo=meta)
![Graphics API](https://img.shields.io/badge/Graphics%20API-Vulkan-red?style=flat-square&logo=vulkan)
![Framework](https://img.shields.io/badge/Framework-XRI%203.0-green?style=flat-square)

---

## 📖 Sobre o Projeto

O **Expoverse** é uma plataforma imersiva desenvolvida para solucionar o gargalo de acessibilidade e preservação de acervos biológicos em museus físicos. O projeto recria o ambiente do Museu de Ciências Morfológicas da UFRN, permitindo que usuários explorem espécimes raros — como peças marinhas e osteológicas — em escala e detalhe impossíveis no ambiente físico.

Para superar as limitações das malhas poligonais tradicionais, o Expoverse utiliza **3D Gaussian Splatting (3DGS)**: uma técnica de representação volumétrica baseada em primitivas Gaussianas 3D que permite renderização fotorrealista a partir de fotografias reais. A implementação é executada diretamente no hardware Android do Meta Quest, via *Compute Shaders* e API gráfica Vulkan, priorizando desempenho estável e baixa latência para minimizar desconforto visual.

## ✨ Principais Funcionalidades

- **Renderização Fotorrealista:** Implementação de 3DGS rodando via *Compute Shaders*, suportando datasets com milhões de splats por espécime capturado.
- **Locomoção VR Avançada:** Sistema de movimentação contínua e colisão física integrados através do *Locomotion Mediator* e *XR Body Transformer* do XRI 3.0.
- **Interatividade Multimídia:** Painéis informativos e reprodutores de vídeo integrados ao ambiente VR, acionados por gatilhos de interação do usuário.
- **Otimização para Mobile Standalone:** Iluminação global pré-calculada (Baked GI via Progressive GPU), compressão de textura ASTC e pipeline configurado para Vulkan.

## 🛠️ Stack Tecnológico

| Camada | Tecnologia |
|---|---|
| Engine | Unity 6 (Universal Render Pipeline - URP) |
| VR Framework | XR Interaction Toolkit 3.0 (XRI) |
| Decodificador 3DGS | [UnityGaussianSplatting](https://github.com/aras-p/UnityGaussianSplatting) (customizado para URP e Android) |
| Pipeline de Reconstrução | COLMAP (Structure from Motion) → formato `.ply` |
| Mídia | WebM / VP8 (compatibilidade nativa Android/Quest) |
| Plataforma Alvo | Meta Quest 2, 3 e Pro (Standalone Android) |

## 📸 Demo

> *Screenshots e vídeo de demonstração serão adicionados após build final.*

## 🚀 Como Executar (Desenvolvimento)

### Pré-requisitos

- Unity 6 com módulo **Android Build Support** instalado
- Git
- Meta Quest 2, 3 ou Pro com **Modo Desenvolvedor** ativo

### Configuração Inicial

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/expoverse.git
   ```

2. Abra o projeto no Unity 6.

3. Altere a plataforma alvo para **Android** em `File > Build Settings`.

4. Verifique que a API gráfica está configurada para **Vulkan** em `Edit > Project Settings > Player > Other Settings`.

5. Em `Project Settings > XR Plug-in Management > OpenXR`, adicione o **Oculus Touch Controller Profile**.

### Gerando o APK

1. Acesse `File > Build Settings` e adicione a cena principal.
2. Certifique-se de que **Export Project** está **desmarcado**.
3. Clique em **Build**.
4. Instale no dispositivo via SideQuest ou ADB:
   ```bash
   adb install Expoverse.apk
   ```

## ⚠️ Limitações Conhecidas

- O desempenho de renderização varia conforme a densidade do dataset `.ply` — datasets muito densos podem exigir downsampling para manter framerate estável no Quest 2.
- A compatibilidade do *UnityGaussianSplatting* com Android requereu modificações no shader original; builds para outras plataformas podem necessitar de ajustes adicionais.
- Reprodução de vídeo testada com arquivos WebM/VP8; outros codecs não foram validados no ambiente standalone.

## 👨‍💻 Autor

**Alan Dionisio P. Nogueira**
Pesquisador e Desenvolvedor de Software
*Escola de Ciências e Tecnologia | TEAM Lab — Universidade Federal do Rio Grande do Norte (UFRN)*

---

## 📄 Licença

> *MIT*

---

*Projeto desenvolvido como parte da Residência em TIC do iRede.
