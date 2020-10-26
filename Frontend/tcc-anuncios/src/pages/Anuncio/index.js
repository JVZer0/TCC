import React, { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css';
import '../Anuncio/style.css';

import Logo from '../../assets/image/Capturar.PNG';
import CoracaoBranco from '../../assets/image/imagemCoracaoBranco.png';
import CoracaoPreto from '../../assets/image/imagemCoracaoPreto.png';

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function Anuncio(props){

    const [infos, setInfos] = useState(props.location.state);
    const [anuncioDetalhado, setAnuncioDetalhado] = useState(props.location.state);
    const [imagem1, setImagens1] = useState();

    const consultarAnuncioDetalhado = async () => {
        try{
            const resp = await api.consultarAnuncioDetalhado(infos.x.idAnuncio);
            setAnuncioDetalhado(resp);
            setImagens1(resp.imagens[0].textoImagem);
        }
        catch (e) {
        }
    }

    useEffect(() => {
        consultarAnuncioDetalhado();
      }, []);

    const [favorito, setFavorito] = useState(false);

    return(
        <div>
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname:"/Home", state: infos.infos}} ><img class="logo" src={Logo} width="150" height="27px" alt=''/></Link>
                </div> 
                <div className="barraPesquisa">
                    <input className="koko2 form-control" type="text" placeholder="Pesquisa"></input>
                </div>
                <div className="meio"> 
                    <Link class="hihi meio" to={{ pathname: "/MeuPerfil", state: infos.infos }}>Meu perfil</Link>
                    <Link class="hihi meio" to={{ pathname: "/MeusAnuncios", state: infos.infos }}>Meus Anuncios</Link>
                    <Link class="hihi meio" to={{ pathname: "/MeusFavoritos", state: infos.infos }}>Meus Favoritos</Link>
                </div>
                <div>
                    <Link  class="hihi" to="/Anunciar"><button class="botao">Anunciar</button></Link>
                </div>
            </div>
                <div className="patota">
                
                    <div className="patota1">
                            <div className="aha">
                                <div className="linin">
                                    <img src={api.consultarImagem(imagem1)} width='100%' height='100%' alt=''></img>
                                </div>
                                <div className="linin1">
                                    <div className="linin2"></div>
                                    <div className="linin2"></div>
                                    <div className="linin2"></div>
                                    <div className="linin2"></div>
                                    <div className="linin2"></div>
                                    <div className="linin2"></div>
                                </div>
                            </div>

                        <div className="lin">
                                <h6>Marca: {anuncioDetalhado.marca}</h6>
                                <h6>Tamanho: {anuncioDetalhado.tamanho}</h6>
                                <h6>Gênero: {anuncioDetalhado.genero}</h6>
                                <h6>Condição: {anuncioDetalhado.condicao}</h6>
                                <h6>Tipo de produto: {anuncioDetalhado.produto}</h6>
                        </div>
                    </div>

                    <div className="ehe">
                        <div className="uhu">
                            <div className="kkkk">
                                <h3>Titulo: {anuncioDetalhado.titulo}</h3>
                                <h5>Preço: {anuncioDetalhado.preco}</h5>
                                <h5>Descrição: {anuncioDetalhado.descricao}</h5>
                            </div>
                            <div className="uin">
                                {
                                    favorito == true ? <div className="ain"><img class="imag" src={CoracaoPreto} width="50px" height="45px" alt=''/></div>
                                    :   <button className="ain"><img class="imag" src={CoracaoBranco} width="50px" height="45px" alt=''></img></button>
                                }
                            </div>
                        </div>

                        <h5 className="ihi">Informações do anunciante</h5>

                        <div className="oho">             
                            <h6>Celular: {anuncioDetalhado.celular}</h6>
                            <h6>Email: {anuncioDetalhado.email}</h6>
                            <h6>Estado: {anuncioDetalhado.estado}</h6>
                            <h6>Cidade: {anuncioDetalhado.cidade}</h6>
                        </div>
                    </div>
                </div>

            <div className="perguntas">
                <div className="hum">
                    <div>
                        <label className="an">Dúvida:</label>
                        <input className="caixa" type="text"></input>
                        <button className="de">Perguntar</button>
                    </div>
                </div>

                <h3 className="vaiamerda">Perguntas</h3>

                <div className="ham">
                    <label className="him">Pergunta:</label>
                    <label className="him">Resposta:</label>
                </div>
            </div>

            <div className="rodape">
                <div className="tey">
                    <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                </div>
            </div>
        </div>
    )
}