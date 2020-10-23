import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Anuncio/style.css'

import Logo from '../../assets/image/Capturar.PNG'
import Favoritar from '../../assets/image/favoritar.png'

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';


export default function Anuncio(props){
    const [infos, setInfos] = useState(props.location.state);

    return(
        <div>
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to="/" ><img class="logo" src={Logo} width="150" height="27px" alt=''/></Link>
                </div> 
                <div className="barraPesquisa">
                    <input className="koko2 form-control" type="text" placeholder="Pesquisa"></input>
                </div>
                <div className="meio"> 
                    <Link class="hihi meio" to={{ pathname: "/MeuPerfil", state: infos }}>Meu perfil</Link>
                    <Link class="hihi meio" to={{ pathname: "/MeusAnuncios", state: infos}}>Meus Anuncios</Link>
                    <Link class="hihi meio" to={{pathname: "/MeusFavoritos", state: infos}}>Meus Favoritos</Link>
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
                            <h6>Marca:</h6>
                            <h6>Tamanho:</h6>
                            <h6>Gênero:</h6>
                            <h6>Condição:</h6>
                            <h6>Tipo de produto:</h6>
                    </div>
                </div>

                <div className="ehe">
                    <div className="uhu">
                        <div className="kkkk">
                            <h3>Titulo:</h3>
                            <h5>Preço:</h5>
                            <h5>Descrição:</h5>
                        </div>
                        <div className="uin">
                        <button className="ain"><img class="imag" src={Favoritar} width="55px" height="50px" alt=''></img></button>
                        </div>
                    </div>

                    <h5 className="ihi">Informações do anunciante</h5>

                    <div className="oho">
                        <h6>Celular:</h6>
                        <h6>Email:</h6>
                        <h6>Cidade:</h6>
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