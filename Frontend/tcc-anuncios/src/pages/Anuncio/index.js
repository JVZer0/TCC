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

    console.log(props.location.state);
    const [infos, setInfos] = useState(props.location.state);

    const consultarAnuncioDetalhado = async () => {
        try{
            const resp = await api.consultarAnuncioDetalhado(infos.x.idAnuncio);
            console.log(resp)
            setTitulo(resp.data.titulo);
            setDescricao(resp.data.descricao);
            setProduto(resp.data.tipoDoProduto);
            setCondicao(resp.data.condicao);
            setGenero(resp.data.genero);
            setMarca(resp.data.marca);
            setTamanho(resp.data.tamanho);
            setPreco(resp.data.preco);
            setEstado(resp.data.estado);
            setCidade(resp.data.cidade);
            setCelular(resp.data.celular);
            setEmail(resp.data.email)
        }
        catch (e) {
            console.log(e.response)
        }
    }

    useEffect(() => {
        consultarAnuncioDetalhado();
      }, []);

    const [titulo, setTitulo] = useState();
    const [descricao, setDescricao] = useState();
    const [produto, setProduto] = useState();
    const [condicao, setCondicao] = useState();
    const [genero, setGenero] = useState();
    const [marca, setMarca] = useState();
    const [tamanho, setTamanho] = useState();
    const [preco, setPreco] = useState();
    const [estado, setEstado] = useState();
    const [cidade, setCidade] = useState();
    const [celular, setCelular] = useState();
    const [email, setEmail] = useState();

    const [favorito, setFavorito] = useState(false);

    return(
        <div>
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to="/Home" ><img class="logo" src={Logo} width="150" height="27px" alt=''/></Link>
                </div> 
                <div className="barraPesquisa">
                    <input className="koko2 form-control" type="text" placeholder="Pesquisa"></input>
                </div>
                <div className="meio"> 
                    <Link class="hihi meio" to={{ pathname: "/MeuPerfil", state: infos }}>Meu perfil</Link>
                    <Link class="hihi meio" to={{ pathname: "/MeusAnuncios", state: infos }}>Meus Anuncios</Link>
                    <Link class="hihi meio" to={{ pathname: "/MeusFavoritos", state: infos }}>Meus Favoritos</Link>
                </div>
                <div>
                    <Link  class="hihi" to="/Anunciar"><button class="botao">Anunciar</button></Link>
                </div>
            </div>

            <div className="patota">
                
                <div className="patota1">
                    <div className="aha">
                        <div className="linin"></div>
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
                            <h6>Marca: {marca}</h6>
                            <h6>Tamanho: {tamanho}</h6>
                            <h6>Gênero: {genero}</h6>
                            <h6>Condição: {condicao}</h6>
                            <h6>Tipo de produto: {produto}</h6>
                    </div>
                </div>

                <div className="ehe">
                    <div className="uhu">
                        <div className="kkkk">
                            <h3>Titulo: {titulo}</h3>
                            <h5>Preço: {preco}</h5>
                            <h5>Descrição: {descricao}</h5>
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
                        <h6>Celular: {celular}</h6>
                        <h6>Email: {email}</h6>
                        <h6>Estado: {estado}</h6>
                        <h6>Cidade: {cidade}</h6>
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