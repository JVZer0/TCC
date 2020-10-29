import React, { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Excluir anuncio/style.css'

import Logo from '../../assets/image/Capturar.PNG'

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();

export default function InativarAnuncio(props){
    const [infos, setInfos] = useState(props.location.state);

    return(
        <div className="dina">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname:"/Home", state: infos.infos}} ><img class="logo" src={Logo} width="150" height="27px" alt=''/></Link>
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

            <div className="nan">
                <h5 className="nat">O Anuncio será desativado</h5> 
                <div className="sahaha">
                    <button className="botoxo">Não</button>
                    <button className="botoxo">Sim</button>
                </div>
            </div>
        </div>
    )
}