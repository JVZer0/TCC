import React, { useState, useEffect, Component } from "react";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";
import ReactDOM from 'react-dom';
import "react-responsive-carousel/lib/styles/carousel.min.css";
import { Carousel } from 'react-responsive-carousel';

import '../../components/Cabecalho/cabecalho.css';
import '../Anuncio/style.css';

import Logo from '../../assets/image/Capturar.PNG';
import CoracaoBranco from '../../assets/image/imagemCoracaoBranco.png';
import CoracaoPreto from '../../assets/image/imagemCoracaoPreto.png';

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function Anuncio(props){
    const navegacao = useHistory();

    const [infos, setInfos] = useState(props.location.state);
    const [anuncioDetalhado, setAnuncioDetalhado] = useState(props.location.state);
    const [perguntasERespotas, setPerguntasERespotas] = useState([props.location.state]);
    const [imagem1, setImagens1] = useState();
    const [pergunta, setPergunta] = useState('');
    const [imagens, setImagens] = useState([]);
    const [favorito, setFavorito] = useState(false);
    
    const consultarAnuncioDetalhado = async () => {
        try{
            const resp = await api.consultarAnuncioDetalhado(infos.x.idAnuncio);
            setAnuncioDetalhado(resp);
            setImagens1(resp.imagens[0].textoImagem);
            setPerguntasERespotas(resp.perguntasERespotas);
            setImagens(resp.imagens)
        }
        catch (e) {

        }
    }

    const perguntar = async (idDonoAnuncio) => {
        try{
            const modelo = {
                Texto: pergunta,
                IdUsuarioPerguntador: infos.infos.idUsuario,
                IdUsuarioRespondedor: idDonoAnuncio,
                IdAnuncio: infos.x.idAnuncio
            };
            const resp = await api.perguntar(modelo);
            window.location.reload();
        }
        catch (e) {

        }
    }

    const favoritar = async () => {
        try{
            const resp = await api.favoritarAnuncio(infos.x.idAnuncio, infos.infos.idUsuario);
        }
        catch (e){

        }
    }

    const favoritado = async () => {
        try{
            const resp = await api.favoritado(infos.x.idAnuncio, infos.infos.idUsuario);
            setFavorito(resp);
            console.log(resp)
        }   
        catch (e){

        }
    }


    useEffect(() => {
        consultarAnuncioDetalhado();
        favoritado();
      }, []);

    return(
        <div>
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname:"/Home", state: infos.infos}} ><img class="logo" src={Logo} width="180" height="34px" alt=''/></Link>
                </div> 

                <div className="barraPesquisa hihi">
                    <Link to={{pathname:"/Home", state: infos.infos}}>Fazer novas consultas</Link>
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
                            <Carousel>
                                {imagens.map(x =>
                                    <img src={api.consultarImagem(x.textoImagem)} alt=""></img>
                                )}
                            </Carousel>
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
                                                    :   <button className="ain" onClick={favoritar} onClick={favoritado} ><img class="imag" src={CoracaoBranco} width="50px" height="45px" alt=''></img></button>
                                }
                            </div>
                        </div>
                        <div className="lin">
                            <h6>Marca: {anuncioDetalhado.marca}</h6>
                            <h6>Tamanho: {anuncioDetalhado.tamanho}</h6>
                            <h6>Gênero: {anuncioDetalhado.genero}</h6>
                            <h6>Condição: {anuncioDetalhado.condicao}</h6>
                            <h6>Tipo de produto: {anuncioDetalhado.produto}</h6>
                        </div>

                        <hr style={{height:"0.8px",width:"100%", color:"black", background:"black", margin:"0"}}></hr>

                        <h4 className="ihia">Informações do anunciante</h4>

                        <div className="oho">             
                            <h6>Celular: {anuncioDetalhado.celularVendedor}</h6>
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
                        <input className="caixa" type="text" value={pergunta} onChange={e => setPergunta(e.target.value)}></input>
                        <button className="de" onClick={() => perguntar(anuncioDetalhado.idDonoAnuncio)}>Perguntar</button>
                    </div>
                </div>

                <h3 className="vaiamerda">Perguntas</h3>
                
                {
                    perguntasERespotas.map(x =>
                        <div className="ham">
                            <label className="him">Pergunta: {x.pergunta}</label>
                            <label className="himb">Resposta: {x.respondida == true && x.resposta != null 
                                ? x.resposta 
                                :   anuncioDetalhado.idDonoAnuncio == infos.infos.idUsuario 
                                    ? <Link to={{ pathname: "/Responder", state: {infos, x}}}>Responder</Link> 
                                    : <p style={{color:"#fe8d27"}}>Ainda não respondida</p>
                            }</label>
                        </div>
                )}
            </div>

            <div className="rodape">
                <div className="tey">
                    <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                </div>
            </div>
        </div>
    )
}